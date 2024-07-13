using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory;
        public UserRepository(IMapper mapper, IDbContextFactory<MainContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task<PagedData<User>> GelAllAsync(CancellationToken cancellationToken = default)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var users = _mapper.Map<List<User>>(await context.Cars.ToListAsync(cancellationToken));
                var count = users.Count;
                var pageCount = (int)Math.Ceiling((double)count / 8);

                return new PagedData<User>(users, count, pageCount);
            }
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                return _mapper.Map<User>(user);
            }
        }
    }
}