using AutoMapper;
using ServicePattern1.DataAccess.Models;
using ServicePattern1.Service.Models;

namespace ServicePattern1.Service.Mapper
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<GetDbOrderModel, GetOrders>();
        }
    }

    public static class ConfigureServiceMapper
    {
        public static IMapper CreateMapper(Profile? customProfile = null)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceMappingProfile());
                if (customProfile != null)
                    cfg.AddProfile(customProfile);
            });

            return config.CreateMapper();
        }
    }
}
