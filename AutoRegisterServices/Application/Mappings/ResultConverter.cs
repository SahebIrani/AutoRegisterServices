using AutoMapper;

using AutoRegisterServices.Application;

namespace AutoRegisterServices.Mappings
{
    public class ResultConverter : IResultConverter
    {
        private readonly IMapper mapper;

        public ResultConverter()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PeopleProfile>();
                cfg.AddProfile<CustomersProfile>();
            }).CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}
