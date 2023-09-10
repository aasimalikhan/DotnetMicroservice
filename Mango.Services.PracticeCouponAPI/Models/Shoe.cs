using System.ComponentModel.DataAnnotations;

namespace Mango.Services.PracticeCouponAPI.Models
{
	public class Shoe
	{
		[Key]
		public int ShoeId { get; set; }
		[Required]
		public string ShoeBrand { get; set; }
		[Required]
		public int ShoePrice { get; set; }
		[Required]
		public int ShoeSalePrice { get; set; }
	}
}
