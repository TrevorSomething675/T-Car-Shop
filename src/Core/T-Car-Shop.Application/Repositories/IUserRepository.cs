using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<PagedData<UserEntity>> GelAll(CancellationToken cancellationToken = default);
    }
}
