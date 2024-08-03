using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using T_Car_Shop.Core.Enums;
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

		public async Task<Car> GetAsync(CarSpecification specification, CancellationToken cancellationToken = default)
		{
			var car = _mapper.Map<Car>(await _carRepository.GetAsync(specification, cancellationToken));
			if (car == null)
				throw new NotFoundException("Car not found");

			foreach (var image in car.Images)
			{
				image.Base64String = await _minioService.GetObjectAsync(image.Path);
			}
			return car;
		}

		public async Task<PagedData<Car>> GetAllAsync(CarSpecification specification, CancellationToken cancellationToken = default)
		{
			var cars = _mapper.Map<PagedData<Car>>(await _carRepository.GetAllAsync(specification, cancellationToken));
			try 
			{ 
				switch (specification.ImagesFillingType)
				{
					case ImagesFillingType.WithoutImages:
						break;

					case ImagesFillingType.WithAllImages:
						foreach (var car in cars.Items)
						{
							foreach (var img in car.Images)
							{
								img.Base64String = await _minioService.GetObjectAsync(img.Path, cancellationToken);
							}
						}
						break;

					case ImagesFillingType.WithFirstImage:
						foreach (var car in cars.Items)
						{
							var firstImage = car.Images.First();
							firstImage.Base64String = await _minioService.GetObjectAsync(firstImage.Path, cancellationToken);
						}
						break;
				}
			}
			catch(Exception ex)
			{

			}

			return cars;
		}
	}
}