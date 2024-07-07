using T_Car_Shop.DataAccess.Abstractions.Repositories;
using T_Car_Shop.DataAccess.Entities;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IDbContextFactory<MainContext> _dbContextFactory;
        public CarRepository(IDbContextFactory<MainContext> dbContextFactory) 
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<PagedResult<CarEntitiy>> GetAll()
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var cars = await context.Cars.ToListAsync();
                var count = cars.Count;
                var pageCount = (int)Math.Ceiling((double)count / 8);

                return new PagedResult<CarEntitiy>
                {
                    Items = cars,
                    Count = count,
                    PageCount = pageCount
                };
            }
        }
    }
}