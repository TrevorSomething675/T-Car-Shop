using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
    public interface ICarRepository
    {
        Task<CarEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PagedData<CarEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CarEntity> UpdateAsync(CarEntity car, CancellationToken cancellationToken = default);
        Task<CarEntity> CreateAsync(CarEntity car, CancellationToken cancellationToken = default);
        Task<CarEntity> RemoveAsync(Guid carId, CancellationToken cancellationToken = default);
    }
}