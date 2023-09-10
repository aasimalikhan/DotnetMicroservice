using Mango.Services.CouponAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using AutoMapper;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>> (objList);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(obj);
                //CouponDto couponDto = new CouponDto()
                //{
                //    CouponId = obj.CouponId;
                //    ...
                //}
                //automapper 
                //_response.Result = obj;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByName/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
              
                _response.Result = _mapper.Map<CouponDto>(obj);
                //CouponDto couponDto = new CouponDto()
                //{
                //    CouponId = obj.CouponId;
                //    ...
                //}
                //automapper 
                //_response.Result = obj;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                //CouponDto couponDto = new CouponDto()
                //{
                //    CouponId = obj.CouponId;
                //    ...
                //}
                //automapper 
                //_response.Result = obj;
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                //entity framework will do everything related to update -> find record and then updates
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                //CouponDto couponDto = new CouponDto()
                //{
                //    CouponId = obj.CouponId;
                //    ...
                //}
                //automapper 
                //_response.Result = obj;
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                //entity framework will do everything related to update -> find record and then updates
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
         
                _response.Result = obj;

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }
    }
}
