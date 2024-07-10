using T_Car_Shop.Infrastructure.Models;
using T_Car_Shop.DataAccess.Entities;
using T_Car_Shop.Web.Models.Car;
using AutoMapper;

namespace T_Car_Shop.Web.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile() 
        {
            CreateMap<CarRequest, Car>();
            CreateMap<Car, CarEntity>();
            CreateMap<Car, CarResponse>();
        }
    }
}