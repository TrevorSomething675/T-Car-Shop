using T_Car_Shop.Application.Repositories;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Entities;
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

        public async Task<PagedData<CarEntity>> GetAll(CancellationToken cancellationToken = default)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var cars = await context.Cars.ToListAsync(cancellationToken);
                var count = cars.Count;
                var pageCount = (int)Math.Ceiling((double)count / 8);

                return new PagedData<CarEntity>(cars, count, pageCount);
            }
        }

        public async Task<CarEntity> Update(CarEntity car, CancellationToken cancellationToken = default)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Modified;
                await context.SaveChangesAsync(cancellationToken);

                return car;
            }
        }
        public async Task<CarEntity> Create(CarEntity car, CancellationToken cancellationToken = default)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var result = context.Cars.Add(car);
                await context.SaveChangesAsync(cancellationToken);
                return result.Entity;
            }
        }

        public async Task<CarEntity> Remove(Guid carId, CancellationToken cancellationToken = default)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var car = await context.Cars.FirstOrDefaultAsync(c => c.Id == carId, cancellationToken);
                var result = (car == null) ? null : context.Remove(car).Entity;
                await context.SaveChangesAsync();
                return result;
            }
        }
    }
}