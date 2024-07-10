using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Application.Services;
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

        public async Task<PagedData<Car>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var pagedCars = await _carRepository.GetAll(cancellationToken);
            var cars = _mapper.Map<PagedData<Car>>(pagedCars);

            return cars;
        }

        public async Task<Result<Car>> CreateAsync(Car car, CancellationToken cancellationToken = default)
        {
            var createdCar = await _carRepository.Create(_mapper.Map<CarEntity>(car));
            return new Result<Car>(_mapper.Map<Car>(createdCar));
        }

        public async Task<Result<Car>> UpdateAsync(Car car, CancellationToken cancellationToken = default)
        {
            var updatedCar = await _carRepository.Update(_mapper.Map<CarEntity>(car));
            return new Result<Car>(_mapper.Map<Car>(updatedCar));
        }

        public async Task<Result<Car>> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var removedCar = await _carRepository.Remove(id, cancellationToken);
            return new Result<Car>(_mapper.Map<Car>(removedCar));
        }
    }
}