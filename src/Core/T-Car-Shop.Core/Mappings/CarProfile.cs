using T_Car_Shop.Core.Models.Presentation.Car;
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
            CreateMap<CarRequest, Car>();
            CreateMap<Result<CarRequest>, Result<Car>>();

            CreateMap<Car, CarEntity>().ReverseMap();
            CreateMap<Result<Car>,  Result<CarEntity>>().ReverseMap();

            CreateMap<Car, CarResponse>();
            CreateMap<Result<Car>, Result<CarResponse>>();
        }
    }
}