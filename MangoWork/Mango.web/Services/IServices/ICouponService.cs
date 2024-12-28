using Mango.web.Models;
namespace Mango.web.Services.IServices
{
    public interface ICouponService
    {
        
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> GetByIdCouponAsync(int id);
        Task<ResponseDto?> GetByCouponCodeAsync(string couponCode);

        Task<ResponseDto?> DeleteCouponsAsync(int id);

        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);

    }
}
