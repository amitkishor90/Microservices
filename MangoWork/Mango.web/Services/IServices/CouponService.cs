using Mango.web.Models;
using Mango.web.Utility;
using static Mango.web.Utility.SD;

namespace Mango.web.Services.IServices
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

       

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
          return  await _baseService.sendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                url = SD.CouponAPIBase + "/api/coupon/GetAllCoupons",
                AccessToken = ""
            });
        }

        public async Task<ResponseDto?> GetByCouponCodeAsync(string couponCode)
        {
           return await _baseService.sendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                url = SD.CouponAPIBase + "/api/coupon/GetByCouponCode/" + couponCode,
                AccessToken = ""
            });
        }

        public async Task<ResponseDto?> GetByIdCouponAsync(int id)
        {
          return await _baseService.sendAsync(new RequestDto
           {
               ApiType = ApiType.GET,
               url = SD.CouponAPIBase + "/api/coupon/GetByIdCoupon/" + id,
               AccessToken = ""
           });
        }

        public async Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            return await _baseService.sendAsync(new RequestDto
            {
                ApiType = ApiType.DELETE,
                url = SD.CouponAPIBase + "/api/coupon/Delete/" + id,
                AccessToken = ""
            });
        }

        public Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return _baseService.sendAsync(new RequestDto
            {
                ApiType = ApiType.POST,
                url = SD.CouponAPIBase + "/api/coupon",
                AccessToken = "",
                Data = couponDto
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
           return await _baseService.sendAsync(new RequestDto
           {
               ApiType = ApiType.PUT,
               url = SD.CouponAPIBase + "/api/coupon/Put/" ,
               AccessToken = "",
               Data = couponDto
           });
        }
    }
}
