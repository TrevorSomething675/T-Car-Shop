using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
	public class MaufacturerProfile : Profile
	{
		public MaufacturerProfile()
		{
			CreateMap<Manufacturer, ManufacturerEntity>().ReverseMap();
			CreateMap<PagedData<Manufacturer>, PagedData<ManufacturerEntity>>().ReverseMap();
		}
	}
}