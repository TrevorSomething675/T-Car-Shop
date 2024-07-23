using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
	public interface ICarService
	{
		Task<Car> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<PagedData<Car>> GetAllAsync(GetCarsFilterModel filter, CancellationToken cancellationToken = default);
	}
}