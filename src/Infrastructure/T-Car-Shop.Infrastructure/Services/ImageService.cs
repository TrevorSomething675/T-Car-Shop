using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Enums;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Infrastructure.Services
{
	public class ImageService : IImageService
	{
		private readonly IMinioService _minioService;
		public ImageService(IMinioService minioService) 
		{
			_minioService = minioService;
		}
		public async Task FillImages(Car car, ImagesFillingType fillingType, CancellationToken cancellationToken = default)
		{
			switch (fillingType)
			{
				case ImagesFillingType.WithAllImages:
					foreach (var img in car.Images)
					{
						img.Base64String = await _minioService.GetObjectAsync(img.Path, cancellationToken);
					}
					break;

				case ImagesFillingType.WithFirstImage:
					var image = car?.Images?.FirstOrDefault();

					if (image != null)
						image.Base64String = await _minioService.GetObjectAsync(image.Path, cancellationToken);
					break;
			}
		}

		public async Task FillImages(PagedData<Car> cars, ImagesFillingType fillingType, CancellationToken cancellationToken = default)
		{
			switch (fillingType)
			{
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
						var image = car?.Images?.FirstOrDefault(); // Это нужно для того чтобы порядок получения не был нарушен.

						if (image != null)
							image.Base64String = await _minioService.GetObjectAsync(image.Path, cancellationToken);
					}
					break;
			}
		}
	}
}