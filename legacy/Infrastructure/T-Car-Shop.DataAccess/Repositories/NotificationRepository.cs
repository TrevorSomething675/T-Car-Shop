using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Extensions;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.DataAccess.Repositories
{
	public class NotificationRepository : INotificationRepository
	{
		private readonly IDbContextFactory<MainContext> _dbContextFactory;
		public NotificationRepository(IDbContextFactory<MainContext> dbContextFactory) 
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<PagedData<NotificationEntity>> GetNotifications(
			NotificationsSpecification specification, 
			CancellationToken cancellationToken = default)
		{
			await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
			{
				var notifications = await context.Notifications
					.AsNoTracking()
					.Includes(specification.Includes)
					.Where(specification.Filter)
					.OrderBy(specification.OrderBy)
					.ToListAsync(cancellationToken);

				var pagedNotifications = notifications
					.Skip((specification.PageNumber - 1) * 8)
					.Take(specification.PageNumber * 8)
					.ToList();

				var count = notifications.Count;
				var pageCount = (int)Math.Ceiling((double)count / 8);

				return new PagedData<NotificationEntity>(pagedNotifications, count, pageCount);
			}
		}
	}
}