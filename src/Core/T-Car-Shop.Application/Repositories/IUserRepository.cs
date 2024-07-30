using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<UserEntity> GetByNameAsync(string name, CancellationToken cancellationToken = default);
		Task<PagedData<UserEntity>> GelAllAsync(UserSpectification spectification, CancellationToken cancellationToken = default);
        Task<UserEntity> CreateAsync(UserEntity user, CancellationToken cancellationToken = default);
    }
}