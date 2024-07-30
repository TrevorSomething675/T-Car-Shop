using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.DataAccess;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
	public class RoleProfile : Profile
	{
		public RoleProfile() 
		{
			CreateMap<Role, RoleEntity>().ReverseMap();
		}
	}
}