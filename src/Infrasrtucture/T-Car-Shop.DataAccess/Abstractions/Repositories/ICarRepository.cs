using T_Car_Shop.DataAccess.Entities;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.DataAccess.Abstractions.Repositories
{
    public interface ICarRepository
    {
        Task<PagedResult<CarEntitiy>> GetAll();
    }
}
