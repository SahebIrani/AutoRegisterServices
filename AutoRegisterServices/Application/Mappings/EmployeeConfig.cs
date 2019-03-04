using AutoRegisterServices.Application.Entities;
using AutoRegisterServices.Application.Results;

using Mapster;

using Microsoft.Extensions.DependencyInjection;

namespace AutoRegisterServices.Mappings
{
    public static class EmployeeConfig
    {
        public static IServiceCollection AddMapsterConfig(this IServiceCollection services)
        {
            TypeAdapterConfig<Employee, EmployeeResult>.NewConfig().Map(dest => dest.Name, src => $"{src.FirstName} {src.FamilyName}");

            return services;
        }
    }
}
