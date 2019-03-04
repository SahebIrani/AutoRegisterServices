using Autofac;
using Autofac.Configuration;

using AutoRegisterServices.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoRegisterServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPublic();
            services.AddPrivate(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder) => builder.RegisterModule(new ConfigurationModule(Configuration));

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UsePublic(env);
            app.UsePrivate();
        }
    }
}
