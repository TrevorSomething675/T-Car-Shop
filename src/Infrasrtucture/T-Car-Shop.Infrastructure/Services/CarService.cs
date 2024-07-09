using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Entities;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository, IMapper mapper) 
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<PagedData<Car>> GetAll(CancellationToken cancellationToken = default)
        {
            var pagedCars = await _carRepository.GetAll(cancellationToken);
            var cars = _mapper.Map<PagedData<Car>>(pagedCars);

            return cars;
        }

        public async Task<Result<Car>> Create(Car car)
        {
            var createdCar = await _carRepository.Create(_mapper.Map<CarEntity>(car));
            return new Result<Car>(_mapper.Map<Car>(createdCar));
        }

        public async Task<Result<Car>> Update(Car car)
        {
            var updatedCar = await _carRepository.Update(_mapper.Map<CarEntity>(car));
            return new Result<Car>(_mapper.Map<Car>(updatedCar));
        }
    }
}