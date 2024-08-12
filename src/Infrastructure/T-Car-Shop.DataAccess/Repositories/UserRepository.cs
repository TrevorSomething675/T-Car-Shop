using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Extensions;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<MainContext> _dbContextFactory;
        public UserRepository(IDbContextFactory<MainContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
		public async Task<UserEntity> GetByNameAsync(string name, CancellationToken cancellationToken = default)
		{
			await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				var user = await context.Users
					.AsNoTracking()
					.Include(u => u.Role)
					.FirstOrDefaultAsync(u => u.Name == name, cancellationToken);
				return user;
			}
		}
		public async Task<UserEntity> CreateAsync(UserEntity user, CancellationToken cancellationToken = default)
		{
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                context.Roles.Attach(user.Role);
                var result = context.Users.Add(user);
                await context.SaveChangesAsync(cancellationToken);
                return result.Entity;
            }
		}
		public async Task<PagedData<UserEntity>> GelAllAsync(UserSpectification spectification, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var users = await context.Users
                    .AsNoTracking()
                    .Includes(spectification.Includes)
                    .Where(spectification.Filter)
                    .ToListAsync(cancellationToken);

                var count = users.Count;
                var pageCount = (int)Math.Ceiling((double)count / 8);

                return new PagedData<UserEntity>(users, count, pageCount);
            }
        }
        public async Task<UserEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var user = await context.Users
                    .AsNoTracking()
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                return user;
            }
        }
	}
}