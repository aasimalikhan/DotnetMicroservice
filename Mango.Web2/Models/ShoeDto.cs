using System.ComponentModel.DataAnnotations;

namespace Mango.Services.PracticeCouponAPI.Models.Dto
{
	public class ShoeDto
	{
		public int ShoeId { get; set; } 
		public string ShoeBrand { get; set; }
		public int ShoePrice { get; set; }
	}
}
