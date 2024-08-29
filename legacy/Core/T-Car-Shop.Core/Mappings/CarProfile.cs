using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile() 
        {
            CreateMap<Car, CarEntity>().ReverseMap();
            CreateMap<Result<Car>,  Result<CarEntity>>().ReverseMap();
            CreateMap<PagedData<CarEntity>, PagedData<Car>>()
                .ForMember(src => src.Items, opt => opt.MapFrom(x => x.Items))
                .ForMember(src => src.Count, opt => opt.MapFrom(x => x.Count))
                .ForMember(src => src.PageCount, opt => opt.MapFrom(x => x.PageCount))
                .ReverseMap();

            CreateMap<UserCar, UserCarEntity>().ReverseMap();
        }
    }
}