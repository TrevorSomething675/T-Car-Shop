using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PagedData<User>> GelAllAsync(CancellationToken cancellationToken = default);
    }
}