namespace AutoRegisterServices
{
    using Autofac.Extensions.DependencyInjection;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args) => await BuildWebHost(args).RunAsync();

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureAppConfiguration((builderContext, config) =>
                    {
                        config.AddJsonFile("autofac.json");
                        config.AddEnvironmentVariables();
                    })
                    .ConfigureServices(services => services.AddAutofac())
                    .Build();
        }
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>();
        //        webBuilder.ConfigureAppConfiguration((builderContext, config) =>
        //        {
        //                    //IHostingEnvironment env = builderContext.HostingEnvironment;
        //                    config.AddJsonFile("autofac.json");
        //            config.AddEnvironmentVariables();
        //        });
        //        webBuilder.ConfigureServices(services => services.AddAutofac());
        //    });
    }
}