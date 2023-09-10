using Mango.Services.PracticeCouponAPI.Models.Dto;

namespace Mango.Web2.Service.IService
{
	public interface ICouponService
	{
		Task<ResponseDto?> GetShoeAsync(int shoeId);
		Task<ResponseDto?> GetAllShoesAsync();
		Task<ResponseDto?> CreateShoeAsync(ShoeDto shoeDto);
		Task<ResponseDto?> UpdateShoeAsync(ShoeDto shoeDto);
		Task<ResponseDto?> DeleteShoeAsync(int shoeId);
	}
}
