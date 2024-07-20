using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using T_Car_Shop.Core.Enums;
using T_Car_Shop.Core.Filters;

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
		public async Task<PagedData<Car>> GetAllAsync(GetCarsFilterModel filter, CancellationToken cancellationToken = default)
		{
			var cars = await _carRepository.GetAllAsync(filter, cancellationToken);

			switch (filter.ImagesFillingType)
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

			return _mapper.Map<PagedData<Car>>(cars);
		}
	}
}