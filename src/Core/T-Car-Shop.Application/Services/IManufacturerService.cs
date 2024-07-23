using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
	public interface IManufacturerService
	{
		Task<PagedData<Manufacturer>> GetManufacturersAsync(GetManufacturersFilterModel filter, CancellationToken cancellationToken = default);
	}
}