using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
    public interface ICarService
    {
        Task<Result<Car>> Update(Car car);
        Task<Result<Car>> Create(Car car);
        Task<PagedData<Car>> GetAll(CancellationToken cancellationToken = default);
    }
}