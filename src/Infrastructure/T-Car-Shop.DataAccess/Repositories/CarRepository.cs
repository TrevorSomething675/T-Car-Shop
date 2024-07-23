using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using T_Car_Shop.Core.Specification;

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

        public async Task<CarEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) 
            {
                var car = await context.Cars
                    .Include(c => c.Description)
                    .Include(c => c.Images)
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
                return car;
            }
        }

        public async Task<PagedData<CarEntity>> GetAllAsync(ISpecification<CarEntity> specification, GetCarsFilterModel filter, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var cars = await context.Cars.AsQueryable()
                    .Include(specification.Includes)
                    .Where(specification.Query)
                    .ToListAsync(cancellationToken);

                /*var cars = await context.Cars
                    .Include(c => c.Images)
                    .Include(c => c.Offers)
                    .Skip((filter.PageNumber - 1) * 8)
                    .Take(filter.PageNumber * 8)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                */
                var allCars = await context.Cars
                    .AsNoTracking().ToListAsync(cancellationToken);

                var count = allCars.Count;
                var pageCount = (int)Math.Ceiling((double)count / 8);

                return new PagedData<CarEntity>(cars, count, pageCount);
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