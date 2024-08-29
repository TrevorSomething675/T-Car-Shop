using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;
using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Application.Services
{
	public interface IImageService
	{
		Task FillImages(Car car, ImagesFillingType fillingType, CancellationToken cancellationToken = default);
		Task FillImages(PagedData<Car> cars, ImagesFillingType fillingType, CancellationToken cancellationToken = default);
		Task FillImages(PagedData<Manufacturer> manufacturers, CancellationToken cancellationToken = default);
	}
}