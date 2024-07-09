using T_Car_Shop.Core.Models.DomainModels;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Infrastructure.Abstractions.Services
{
    public interface ICarService
    {
        Task<Result<Car>> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<Car>> UpdateAsync(Car car, CancellationToken cancellationToken = default);
        Task<Result<Car>> CreateAsync(Car car, CancellationToken cancellationToken = default);
        Task<PagedData<Car>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}