using T_Car_Shop.Core.Entities;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
    public interface ICarRepository
    {
        Task<Result<CarEntitiy>> Remove(Guid carId, CancellationToken cancellationToken = default);
        Task<PagedResult<CarEntitiy>> GetAll(CancellationToken cancellationToken = default);
    }
}