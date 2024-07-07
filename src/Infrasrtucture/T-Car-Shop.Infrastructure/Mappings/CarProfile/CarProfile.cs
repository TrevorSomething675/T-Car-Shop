using T_Car_Shop.Infrastructure.Models;
using T_Car_Shop.DataAccess.Entities;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Mappings.CarProfile
{
    public class CarProfile : Profile
    {
        public CarProfile() 
        {
            CreateMap<Car, CarEntitiy>().ReverseMap();
        }
    }
}