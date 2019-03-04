using Microsoft.Extensions.DependencyInjection;

using System;

namespace AutoRegisterServices.Service
{
    public class ServiceLocator
    {
        private ServiceProvider _currentServiceProvider;
        private static ServiceProvider _serviceProvider;

        public ServiceLocator(ServiceProvider currentServiceProvider) => _currentServiceProvider = currentServiceProvider;

        public static ServiceLocator Current => new ServiceLocator(_serviceProvider);

        public static void SetLocatorProvider(ServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public object GetInstance(Type serviceType) => _currentServiceProvider.GetService(serviceType);

        public TService GetInstance<TService>() => _currentServiceProvider.GetService<TService>();

        public object GetRequiredInstance(Type serviceType) => _currentServiceProvider.GetRequiredService(serviceType);

        public TService GetRequiredInstance<TService>() => _currentServiceProvider.GetRequiredService<TService>();
    }
}
