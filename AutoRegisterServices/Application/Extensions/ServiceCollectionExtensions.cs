
using AutoRegisterServices.GraphTypes;
using AutoRegisterServices.Mappings;
using AutoRegisterServices.Service;
using AutoRegisterServices.Services;
using AutoRegisterServices.Services2;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NetCore.AutoRegisterDi;

using OtherAssemblyServices;

using System;
using System.Reflection;

namespace AutoRegisterServices.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCookiePolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        public static void AddSecurityCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void AddGenericRegister(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IThing<>), typeof(GenericThing<>));

            services.AddTransient<Func<string, IShoppingCart>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "API": return serviceProvider.GetService<ShoppingCartAPI>();
                    case "DB": return serviceProvider.GetService<ShoppingCartDB>();
                    default: return serviceProvider.GetService<ShoppingCartCache>();
                }
            });
        }

        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>());
            //services.AddSingleton<IFactory<TService>, Factory<TService>>();
        }

        public static void AddAutoRegisterDi(this IServiceCollection services)
        {
            //Assembly assembly = AppDomain.CurrentDomain.Load(name);
            //Assembly assembly2 = Assembly.LoadFrom(file);
            //var assemblyToScan2 = Assembly.GetAssembly(typeof(Startup));
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Assembly assemblyToScan = Assembly.GetExecutingAssembly();

            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
                .Where(c => c.Name.EndsWith("Service"))
                    .AsPublicImplementedInterfaces();
        }

        public static void AddServiceLocator(this IServiceCollection services) => ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());

        public static IServiceCollection AddScrutor(this IServiceCollection services)
        {
            services.Scan(scan => scan

              .AddTypes(typeof(Service2), typeof(Service3))

              .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
              .AddClasses(c => c.InNamespaceOf(typeof(IService)))
              .AsSelfWithInterfaces()
              .AsMatchingInterface((service, filter) =>
                filter.Where(implementation =>
                 implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
              .WithTransientLifetime()

              .FromExecutingAssembly()
              .FromApplicationDependencies(a => a.FullName.StartsWith("AutoRegisterServices"))
              .AddClasses(c => c.AssignableTo<NewService>(), true)
              .AsMatchingInterface()
              .WithLifetime(ServiceLifetime.Singleton)

              .FromAssemblyOf<IOtherService>()
              .AddClasses(c => c.Where(type => !type.IsAbstract && type.Name.StartsWith("Other")))
              .AsImplementedInterfaces()
              .WithSingletonLifetime()

            );

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = configuration["Info:Version"];
                    document.Info.Title = configuration["Info:Title"];
                    document.Info.Description = configuration["Info:Description"];
                    document.Info.TermsOfService = configuration["Info:TermsOfService"];
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = configuration["Info.Contact:Name"],
                        Email = configuration["Info.Contact:Email"],
                        Url = configuration["Info.Contact:Url"]
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = configuration["Info.License:Name"],
                        Url = configuration["Info.License:Url"]
                    };
                };
            });

            return services;
        }


        public static void AddPublic(this IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();

            services.AddCookiePolicy();

            services.AddSecurityCors();
        }

        public static void AddPrivate(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGenericRegister();

            services.AddFactory<IRandomNumberGenerator, RandomNumberGenerator>();

            services.AddAutoRegisterDi();

            services.AddServiceLocator();

            services.AddScrutor();

            services.AddSwagger(configuration);

            services.AddGraphQl(schema => { schema.SetQueryType<EmployeeType>(); });

            services.AddMapsterConfig();
        }
    }
}
