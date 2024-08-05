using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Repositories
{
	public class UserCarRepository : IUserCarRepository
	{
		private readonly IDbContextFactory<MainContext> _dbContextFactory;
		public UserCarRepository(IDbContextFactory<MainContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<UserCarEntity> CreateAsync(UserCarEntity entity, CancellationToken cancellationToken = default)
		{
			await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				var createdUserCar = await context.UserCars.AddAsync(entity, cancellationToken);
				await context.SaveChangesAsync(cancellationToken);
				return createdUserCar.Entity;
			}
		}
		public async Task<UserCarEntity> DeleteAsync(UserCarEntity entity, CancellationToken cancellationToken = default)
		{
			await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				var userCarToDelete = await context.UserCars
					.FirstOrDefaultAsync(uc => uc.UserId == entity.UserId && uc.CarId == entity.CarId, cancellationToken);

				var deletedUserCar = context.UserCars.Remove(userCarToDelete);
				await context.SaveChangesAsync(cancellationToken);
				return deletedUserCar.Entity;
			}
		}
		public async Task<UserCarEntity> UpdateAsync(UserCarEntity car, CancellationToken cancellationToken = default)
		{
			await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				throw new NotImplementedException();
			}
		}
	}
}