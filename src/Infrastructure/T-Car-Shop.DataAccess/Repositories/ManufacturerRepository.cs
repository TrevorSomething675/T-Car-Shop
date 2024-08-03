using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.DataAccess.Repositories
{
	public class ManufacturerRepository : IManufacturerRepository
	{
		private readonly IDbContextFactory<MainContext> _dbContextFactory;

		public ManufacturerRepository(IDbContextFactory<MainContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<PagedData<ManufacturerEntity>> GetAllAsync(ManufacturerSpecification specification, CancellationToken cancellationToken = default)
		{
			using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				var manufacturers = await context.Manufacturers
					.AsNoTracking()
					.Include(m => m.Images)
					.ToListAsync(cancellationToken);

				var pagedManufacturers = manufacturers
					.Skip((specification.PageNumber - 1) * 8)
					.Take(specification.PageNumber * 8);

				var count = manufacturers.Count();
				var pageCount = (int)Math.Ceiling((double)count / 8);

				return new PagedData<ManufacturerEntity>(pagedManufacturers, count, pageCount);
			}
		}
	}
}