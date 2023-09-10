using Mango.Services.PracticeCouponAPI.Models.Dto;
using Mango.Web2.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web2.Controllers
{
	public class ShoeController : Controller
	{
		private readonly ICouponService _couponService;

		public ShoeController(ICouponService couponService)
		{
			_couponService = couponService;
		}

		public async Task<IActionResult> CouponIndex()
		{
			List<ShoeDto>? list = new();
			ResponseDto? response = await _couponService.GetAllShoesAsync();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ShoeDto>>(Convert.ToString(response.Result));
			}

			return View(list);
		}

		public async Task<IActionResult> CouponCreate()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CouponCreate(ShoeDto model)
		{
			if(ModelState.IsValid)
			{
				ResponseDto? response = await _couponService.CreateShoeAsync(model);

				if(response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(CouponIndex));
				}
			}
			return View(model);
		}
		
		public async Task<IActionResult> CouponDelete(int shoeId)
		{
			ResponseDto? response = await _couponService.GetShoeAsync(shoeId);
			if(response != null && response.IsSuccess)
			{
				ShoeDto? model = JsonConvert.DeserializeObject<ShoeDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> CouponDelete(ShoeDto shoeDto)
		{
			ResponseDto? response = await _couponService.DeleteShoeAsync(shoeDto.ShoeId);
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction(nameof(CouponIndex));
			}
			return View(shoeDto);
		}
	}
}
