using AutoMapper;
using Mango.Services.CouponApi.Dto;
using Mango.Services.CouponApi.Model;

namespace Mango.Services.CouponApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var  mapperConfig = new MapperConfiguration(cfg =>
            {
                 cfg.CreateMap<CouponDto, Coupon>();
                 cfg.CreateMap<Coupon, CouponDto>();
            });
            return mapperConfig;
        }
    }
}
