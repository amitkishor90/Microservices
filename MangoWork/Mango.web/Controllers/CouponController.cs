using Mango.web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Mango.web.Models;
using Newtonsoft.Json;

namespace Mango.web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService )
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> couponDtos = new();
             ResponseDto? responseDto =   await _couponService.GetAllCouponAsync();
             if(responseDto != null && responseDto.IsSuccess)
            {
                  couponDtos = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            return View(couponDtos);
        }
    }
}
