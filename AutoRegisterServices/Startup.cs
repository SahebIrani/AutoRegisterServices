using Autofac;
using Autofac.Configuration;

using AutoRegisterServices.Data;
using AutoRegisterServices.Mappings;
using AutoRegisterServices.Services;
using AutoRegisterServices.Services2;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OtherAssemblyServices;

using System;

namespace AutoRegisterServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc()
                .AddNewtonsoftJson()
                ;

            services.Scan(scan => scan

              .AddTypes(typeof(Service2), typeof(Service3))

              .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
              .AddClasses(c => c.InNamespaceOf(typeof(IService)))
              .AsSelfWithInterfaces()
              .WithTransientLifetime()

              .AddClasses(c => c.AssignableTo<NewService>())
              .AsMatchingInterface()
              .WithLifetime(ServiceLifetime.Singleton)

              .FromAssemblyOf<IOtherService>()
              .AddClasses(c => c.Where(type => !type.IsAbstract && type.Name.StartsWith("Other")))
              .AsImplementedInterfaces()
              .WithSingletonLifetime()

            );

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = Configuration["Info:Version"];
                    document.Info.Title = Configuration["Info:Title"];
                    document.Info.Description = Configuration["Info:Description"];
                    document.Info.TermsOfService = Configuration["Info:TermsOfService"];
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = Configuration["Info.Contact:Name"],
                        Email = Configuration["Info.Contact:Email"],
                        Url = Configuration["Info.Contact:Url"]
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = Configuration["Info.License:Name"],
                        Url = Configuration["Info.License:Url"]
                    };
                };
            });

            services.AddMapsterConfig();
        }

        public void ConfigureContainer(ContainerBuilder builder) => builder.RegisterModule(new ConfigurationModule(Configuration));

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseRouting(routes =>
            {
                routes.MapApplication();
            });

            app.UseCookiePolicy();

            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseDatabaseInitial();
        }
    }
}
