using T_Car_Shop.Core.Models.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.Core.Extensions
{
	public static class IQuerableEntitiesExtensions
	{
		public static IQueryable<CarEntity> Includes(this IQueryable<CarEntity> cars, List<string> includes)
		{
			foreach (var include in includes)
			{
				cars = cars.Include(include);
			}
			return cars;
		}
		public static IQueryable<UserEntity> Includes(this IQueryable<UserEntity> users, List<string> includes)
		{
			foreach (var include in includes)
			{
				users = users.Include(include);
			}
			return users;
		}
		public static IQueryable<NotificationEntity> Includes(this IQueryable<NotificationEntity> notifications, List<string> includes)
		{
			foreach (var include in includes)
			{
				notifications = notifications.Include(include);
			}
			return notifications;
		}
		public static IQueryable<UserNotificationEntity> Includes(this IQueryable<UserNotificationEntity> userNotifications, List<string> includes)
		{
			foreach (var include in includes)
			{
				userNotifications = userNotifications.Include(include);
			}
			return userNotifications;
		}
	}
}
