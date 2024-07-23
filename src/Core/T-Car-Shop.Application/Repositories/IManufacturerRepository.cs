using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
	public interface IManufacturerRepository
	{
		Task<PagedData<ManufacturerEntity>> GetAllAsync(GetManufacturersFilterModel filter, CancellationToken cancellationToken = default);
	}
}