using T_Car_Shop.Core.Models.DataAccess;

namespace T_Car_Shop.Application.Repositories
{
	public interface IRoleRepository
	{
		Task<RoleEntity> GetRoleByName(string name, CancellationToken cancellationToken = default);
	}
}