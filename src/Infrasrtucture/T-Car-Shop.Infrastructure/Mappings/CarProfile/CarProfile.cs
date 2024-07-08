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
            CreateMap<Car, CarEntitiy>().ReverseMap();
            CreateMap<PagedResult<Car>, PagedResult<CarEntitiy>>()
                .ReverseMap();
        }
    }
}