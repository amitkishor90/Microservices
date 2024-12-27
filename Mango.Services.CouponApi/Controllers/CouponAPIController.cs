using Mango.Services.CouponApi.Data;
using Microsoft.AspNetCore.Mvc;
using Mango.Services.CouponApi.Model;
using Mango.Services.CouponApi.Dto;
using AutoMapper;


namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase

    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _responseDto.Result = objList;
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = "Failed to retrieve coupons" + ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id}")]
        public object Get(int id)
        {
            try
            {
                Coupon objectlist = _db.Coupons.FirstOrDefault(x => x.CouponId == id);
                _responseDto.Result = objectlist;
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = "Failed to retrieve coupons" + ex.Message;
            }
            return _responseDto;
        }
    }
}
