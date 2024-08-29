using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
	public interface INotificationRepository
	{
		Task<PagedData<NotificationEntity>> GetNotifications(
			NotificationsSpecification specification,
			CancellationToken cancellationToken = default);
	}
}