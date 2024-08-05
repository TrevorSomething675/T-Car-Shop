using T_Car_Shop.Core.Models.DataAccess;

namespace T_Car_Shop.Application.Repositories
{
	public interface IUserCarRepository
	{
		Task<UserCarEntity> CreateAsync(UserCarEntity entity, CancellationToken cancellationToken = default);
		Task<UserCarEntity> UpdateAsync(UserCarEntity entity, CancellationToken cancellationToken = default);
		Task<UserCarEntity> DeleteAsync(UserCarEntity entity, CancellationToken cancellationToken = default);
	}
}