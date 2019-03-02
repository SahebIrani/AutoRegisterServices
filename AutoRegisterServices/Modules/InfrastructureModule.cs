namespace AutoRegisterServices.Modules
{
    using Autofac;

    using AutoRegisterServices.Data;
    using AutoRegisterServices.Mappings;

    using Microsoft.EntityFrameworkCore;

    public class InfrastructureModule : Module
    {
        public string SQLServerConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(SQLServerConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);

            builder.RegisterType<Context>()
              .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
              .InstancePerLifetimeScope();

            //
            // Register all Types in Chinook.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(ResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
