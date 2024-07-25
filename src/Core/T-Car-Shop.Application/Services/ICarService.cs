using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
	public interface ICarService
	{
		Task<Car> GetByIdAsync(CarSpecification specification, Guid id, CancellationToken cancellationToken = default);
		Task<PagedData<Car>> GetAllAsync(CarSpecification specification, GetCarsFilterModel filter, CancellationToken cancellationToken = default);
	}
}