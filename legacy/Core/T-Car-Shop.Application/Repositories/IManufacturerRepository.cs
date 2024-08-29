using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
	public interface IManufacturerRepository
	{
		Task<PagedData<ManufacturerEntity>> GetAllAsync(ManufacturerSpecification specification, CancellationToken cancellationToken = default);
	}
}