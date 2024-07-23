using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.DataAccess;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
	public class DescriptionProfile : Profile
	{
		public DescriptionProfile() 
		{
			CreateMap<Description, DescriptionEntity>().ReverseMap();
		}
	}
}