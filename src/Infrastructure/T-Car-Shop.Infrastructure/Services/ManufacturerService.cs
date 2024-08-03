using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using T_Car_Shop.Core.Enums;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Services
{
	public class ManufacturerService : IManufacturerService
	{
		private readonly IMapper _mapper;
		private readonly IMinioService _minioService;
		private readonly IManufacturerRepository _manufacturerRepository;
		public ManufacturerService(IManufacturerRepository manufacturerRepository, IMapper mapper, IMinioService minioService) 
		{
			_manufacturerRepository = manufacturerRepository;
			_minioService = minioService;
			_mapper = mapper;
		}
		public async Task<PagedData<Manufacturer>> GetManufacturersAsync(ManufacturerSpecification specification, CancellationToken cancellationToken = default)
		{
			var manufacturers = _mapper.Map<PagedData<Manufacturer>>(await _manufacturerRepository.GetAllAsync(specification, cancellationToken));
			
			switch (specification.ImagesFillingType)
			{
				case ImagesFillingType.WithoutImages:
					break;

				case ImagesFillingType.WithAllImages:
					foreach (var manufacturer in manufacturers.Items)
					{
						foreach (var img in manufacturer.Images)
						{
							img.Base64String = await _minioService.GetObjectAsync(img.Path, cancellationToken);
						}
					}
					break;

				case ImagesFillingType.WithFirstImage:
					foreach (var manufacturer in manufacturers.Items)
					{
						var firstImage = manufacturer.Images.First();
						firstImage.Base64String = await _minioService.GetObjectAsync(firstImage.Path, cancellationToken);
					}
					break;
			}
			
			return manufacturers;
		}
	}
}