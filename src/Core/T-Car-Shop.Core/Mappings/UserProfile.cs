using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Models.Auth;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
	public class UserProfile : Profile
	{
		public UserProfile() 
		{
			CreateMap<RegisterFormModel, User>();
			CreateMap<LoginFormModel, User>();
			CreateMap<User, UserEntity>().ReverseMap();
		}
	}
}