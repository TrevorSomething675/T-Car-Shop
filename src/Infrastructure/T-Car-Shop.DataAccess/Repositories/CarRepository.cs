using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Extensions;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory;
        public CarRepository(IDbContextFactory<MainContext> dbContextFactory, IMapper mapper) 
        {
            _mapper = mapper;
            _dbContextFactory = dbContextFactory;
        }

        public async Task<CarEntity> GetAsync(CarSpecification specification, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var query = context.Cars.AsNoTracking();

                query = query.Include(c => c.UserCar.Where(uc => uc.UserId == specification.UserId));

				var car = await query
					.Includes(specification.Includes)
                    .FirstOrDefaultAsync(specification.Filter, cancellationToken);

                return car;
            }
        }
        public async Task<PagedData<CarEntity>> GetAllAsync(CarSpecification specification, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var query = context.Cars.AsNoTracking();

                query = query.Include(c => c.UserCar.Where(uc => uc.UserId == specification.UserId));

                var cars = await query
					.Includes(specification.Includes)
                    .Where(specification.Filter)
                    .OrderBy(specification.OrderBy)
                    .ToListAsync(cancellationToken);

                var pagedCars = cars
                    .Skip((specification.PageNumber - 1) * 8)
                    .Take(specification.PageNumber * 8);

                var count = cars.ToList().Count;
                var pageCount = (int)Math.Ceiling((double)count / 8);

                return new PagedData<CarEntity>(pagedCars, count, pageCount);
            }
        }
        public async Task<CarEntity> UpdateAsync(CarEntity car, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var result = context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Modified;
                await context.SaveChangesAsync(cancellationToken);

                return result.Entity;
            }
        }
        public async Task<CarEntity> CreateAsync(CarEntity car, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var result = context.Cars.Add(car);
                await context.SaveChangesAsync(cancellationToken);
                return result.Entity;
            }
        }
        public async Task<CarEntity> RemoveAsync(Guid carId, CancellationToken cancellationToken = default)
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