using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
    public interface ICarService
    {
        Task<PagedData<Car>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<Car>> CreateAsync(Car car, CancellationToken cancellationToken = default);
        Task<Result<Car>> UpdateAsync(Car car, CancellationToken cancellationToken = default);
        Task<Result<Car>> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    }
}