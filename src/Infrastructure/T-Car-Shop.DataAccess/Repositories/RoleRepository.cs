using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private readonly IDbContextFactory<MainContext> _dbContextFactory;
		public RoleRepository(IDbContextFactory<MainContext> dbContextFactory) 
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<RoleEntity> GetRoleByName(string name, CancellationToken cancellationToken = default)
		{
			await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				var role = await context.Roles
					.FirstOrDefaultAsync(r => r.Name == name, cancellationToken);

				return role;
			}
		}
	}
}
