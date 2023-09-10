using Mango.Services.PracticeCouponAPI.Models.Dto;
using Mango.Web2.Models;

namespace Mango.Web2.Service.IService
{
	public interface IBaseService
	{
		Task<ResponseDto?> SendAsync(RequestDto requestDto);
	}
}
