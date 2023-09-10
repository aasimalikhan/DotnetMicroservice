using AutoMapper;
using Mango.Services.PracticeCouponAPI.Models.Dto;
using Mango.Services.PracticeCouponAPI.Models;

namespace Mango.Services.PracticeCouponAPI
{
	public class MappingConfig
	{
		public MappingConfig() {
		}

		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<ShoeDto, Shoe>();
				config.CreateMap<Shoe, ShoeDto>();
			});
			return mappingConfig;
		}
	}
}
