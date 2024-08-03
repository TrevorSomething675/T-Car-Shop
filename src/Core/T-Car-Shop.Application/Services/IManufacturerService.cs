using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
	public interface IManufacturerService
	{
		Task<PagedData<Manufacturer>> GetManufacturersAsync(ManufacturerSpecification specification, CancellationToken cancellationToken = default);
	}
}