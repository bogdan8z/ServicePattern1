using AutoMapper;
using ServicePattern1.DataAccess.Models;
using ServicePattern1.Domain;

namespace ServicePattern1.DataAccess.Mapper
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Order, GetDbOrderModel>();
        }
    }

    public static class ConfigureDataAccessMapper
    {
        public static IMapper CreateMapper(Profile? customProfile = null)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DataAccessMappingProfile());
                if (customProfile != null)
                    cfg.AddProfile(customProfile);
            });

            return config.CreateMapper();
        }
    }
}
