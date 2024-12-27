using Mango.Services.CouponApi.Data;
using Microsoft.AspNetCore.Mvc;
using Mango.Services.CouponApi.Model;
using Mango.Services.CouponApi.Dto;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;


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
                _mapper.Map<IEnumerable<CouponDto>>(objList);
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
                _mapper.Map<CouponDto>(objectlist);
                _responseDto.Result = objectlist;
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = "Failed to retrieve coupons" + ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public object GetByCode(string code)
        {
            try
            {
                Coupon objectcode = _db.Coupons.FirstOrDefault(x =>x.CouponCode.ToLower() == code.ToLower());
                if(objectcode == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Coupon not found";
                }
                _mapper.Map<CouponDto>(objectcode);
                _responseDto.Result = objectcode;
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = "Failed to retrieve coupons" + ex.Message;
            }
            return _responseDto;
        }
        [HttpPost]
       // [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            using(var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    Coupon obj = _mapper.Map<Coupon>(couponDto);
                    _db.Coupons.Add(obj);
                    _db.SaveChanges();
                    transaction.Commit();
                    _responseDto.Result = _mapper.Map<CouponDto>(obj);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = ex.Message;
                }
            }   
            return _responseDto;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
      //  [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

    }
}
