using AutoMapper;
using ServicePattern1.API.Models;
using ServicePattern1.Service.Models;

namespace ServicePattern1.API.Mapper
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<GetOrders, GetAllOrdersModel>();
        }
    }

    public static class ConfigureApiMapper
    {
        public static IMapper CreateMapper(Profile? customProfile = null)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiMappingProfile());
                if (customProfile != null)
                    cfg.AddProfile(customProfile);
            });

            return config.CreateMapper();
        }
    }
}
