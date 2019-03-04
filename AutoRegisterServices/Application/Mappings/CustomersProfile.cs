using AutoMapper;

using AutoRegisterServices.Application.Entities;
using AutoRegisterServices.Application.Results;

namespace AutoRegisterServices.Mappings
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile() => CreateMap<Customer, CustomerResult>().ReverseMap();
    }
}
