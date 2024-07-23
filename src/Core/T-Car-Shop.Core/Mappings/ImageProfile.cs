using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.DataAccess;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
	public class ImageProfile : Profile
	{
		public ImageProfile() 
		{
			CreateMap<Image, ImageEntity>().ReverseMap();
			CreateMap<ManufacturerImage, ManufacturerImageEntity>().ReverseMap();
		}
	}
}