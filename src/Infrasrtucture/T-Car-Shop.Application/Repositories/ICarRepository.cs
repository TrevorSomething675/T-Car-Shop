using T_Car_Shop.Core.Entities;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
    public interface ICarRepository
    {
        Task<CarEntity> Update(CarEntity car, CancellationToken cancellationToken = default);
        Task<CarEntity> Create(CarEntity car, CancellationToken cancellationToken = default);
        Task<CarEntity> Remove(Guid carId, CancellationToken cancellationToken = default);
        Task<PagedData<CarEntity>> GetAll(CancellationToken cancellationToken = default);
    }
}