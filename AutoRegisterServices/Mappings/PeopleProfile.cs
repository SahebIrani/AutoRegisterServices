using AutoMapper;

using AutoRegisterServices.Application.Entities;
using AutoRegisterServices.Application.Results;

namespace AutoRegisterServices.Mappings
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile() => CreateMap<Person, PersonResult>().ReverseMap();
    }
}
