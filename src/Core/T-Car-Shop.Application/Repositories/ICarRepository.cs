using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PagedData<Car>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Car> UpdateAsync(Car car, CancellationToken cancellationToken = default);
        Task<Car> CreateAsync(Car car, CancellationToken cancellationToken = default);
        Task<Car> RemoveAsync(Guid carId, CancellationToken cancellationToken = default);
    }
}
