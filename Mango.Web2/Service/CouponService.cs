using Mango.Services.PracticeCouponAPI.Models.Dto;
using Mango.Web.Utility;
using Mango.Web2.Models;
using Mango.Web2.Service.IService;

namespace Mango.Web2.Service
{
    public class CouponService : ICouponService
    {
		private readonly IBaseService _baseService;

		public CouponService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto?> GetShoeAsync(int shoeId)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/shoeapi/GetByCode/" + shoeId
			});
		}
		public async Task<ResponseDto?> GetAllShoesAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/shoeapi"
			});
		}

		public async Task<ResponseDto?> CreateShoeAsync(ShoeDto shoeDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = shoeDto,
				Url = SD.CouponAPIBase + "/api/shoeapi"
			});
		}
		public async Task<ResponseDto?> UpdateShoeAsync(ShoeDto shoeDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = shoeDto,
				Url = SD.CouponAPIBase + "/api/shoeapi"
			});
		}
		public async Task<ResponseDto?> DeleteShoeAsync(int shoeId)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.CouponAPIBase + "/api/shoeapi/" + shoeId
			});
		}
	}
}
