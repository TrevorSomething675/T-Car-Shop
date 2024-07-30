using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
	public interface ICarService
	{
		Task<Car> GetByIdAsync(Guid id, CarSpecification specification, CancellationToken cancellationToken = default);
		Task<PagedData<Car>> GetAllAsync(CarsSpecification specification, GetCarsFilterModel filter, CancellationToken cancellationToken = default);
	}
}