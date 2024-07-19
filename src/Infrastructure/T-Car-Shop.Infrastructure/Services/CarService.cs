using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Services
{
	public class CarService : ICarService
	{
		private readonly ICarRepository _carRepository;
		private readonly IMinioService _minioService;
		private readonly IMapper _mapper;
		public CarService(ICarRepository carRepository, IMinioService minioService, IMapper mapper) 
		{
			_carRepository = carRepository;
			_minioService = minioService;
			_mapper = mapper;
		}
		public async Task<PagedData<Car>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			var cars = await _carRepository.GetAllAsync(cancellationToken);
			foreach (var car in cars.Items)
			{
				foreach (var img in car.Images)
				{
					img.Base64String = await _minioService.GetObjectAsync(img.Path);
				}
			}
			return _mapper.Map<PagedData<Car>>(cars);
		}
	}
}