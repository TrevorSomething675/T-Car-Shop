using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Entities;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Mappings.CarProfile
{
    public class CarProfile : Profile
    {
        public CarProfile() 
        {
            CreateMap<Car, CarEntity>().ReverseMap();
            CreateMap<PagedData<Car>, PagedData<CarEntity>>()
                .ReverseMap();
        }
    }
}