using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.DataAccess;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
	public class OfferProfile : Profile
	{
		public OfferProfile() 
		{
			CreateMap<Offers, OffersEntity>().ReverseMap();
		}
	}
}