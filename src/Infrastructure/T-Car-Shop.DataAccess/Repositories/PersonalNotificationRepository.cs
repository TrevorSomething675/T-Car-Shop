using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Extensions;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.DataAccess.Repositories
{
	public class PersonalNotificationRepository : IPersonalNotificationRepository
	{
		private readonly IDbContextFactory<MainContext> _dbContextFactory;
		public PersonalNotificationRepository(IDbContextFactory<MainContext> dbContextFactory) 
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<PagedData<UserNotificationEntity>> GetAllAsync(PersonalNotificationsSpecification specification, CancellationToken cancellationToken = default)
		{
			await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				var userNotifications = await context.UserNotifications
					.AsNoTracking()
					.Includes(specification.Includes)
					.Where(specification.Filter)
					.OrderBy(specification.OrderBy)
					.ToListAsync(cancellationToken);

				var pagedUserNotifications = userNotifications
					.Skip((specification.PageNumber - 1) * 8)
					.Take(specification.PageNumber * 8);

				var count = userNotifications.Count;
				var pageCount = (int)Math.Ceiling((double)count / 8);

				return new PagedData<UserNotificationEntity>(pagedUserNotifications, count, pageCount);
			}
		}
		public async Task<UserNotificationEntity> UpdateAsync(UserNotificationEntity userNotification, CancellationToken cancellationToken = default)
		{
			await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				var userNotificationEntity = await context.UserNotifications
					.FirstOrDefaultAsync(u => u.Id == userNotification.Id, cancellationToken);

				context.Entry(userNotificationEntity).CurrentValues.SetValues(userNotification);
				await context.SaveChangesAsync(cancellationToken);

				return userNotificationEntity;
			}
		}
	}
}