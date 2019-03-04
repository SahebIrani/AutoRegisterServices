namespace AutoRegisterServices.Modules
{
    using Autofac;

    using AutoRegisterServices.Application;

    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register all Types in AutoRegisterServices
            builder.RegisterAssemblyTypes(typeof(IResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
