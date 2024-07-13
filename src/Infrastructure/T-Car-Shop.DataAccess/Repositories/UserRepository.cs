using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
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

        public Task<PagedData<UserEntity>> GelAll(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                return user;
            }
        }
    }
}