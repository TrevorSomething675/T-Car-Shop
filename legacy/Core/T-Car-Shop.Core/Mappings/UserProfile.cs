using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.UserCar;
using T_Car_Shop.Core.Models.Web.Account;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Models.Web.Auth;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
    public class UserProfile : Profile
	{
		public UserProfile() 
		{
			CreateMap<AccountUserRequest, User>()
				.ForMember(src => src.Name, opt => opt.MapFrom(x => x.NewUserName))
				.ForMember(src => src.Password, opt => opt.MapFrom(x => x.NewPassword));

			CreateMap<RegisterFormModel, User>();
			CreateMap<LoginFormModel, User>();
			CreateMap<User, UserEntity>().ReverseMap();

			CreateMap<UserCarRequest, UserCar>();
			CreateMap<UserCar, UserCarEntity>().ReverseMap();
			CreateMap<UserCar, UserCarResponse>();
		}
	}
}