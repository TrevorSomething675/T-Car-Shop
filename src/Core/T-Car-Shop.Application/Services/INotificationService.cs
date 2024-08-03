using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
	public interface INotificationService
	{
		Task<PagedData<Notification>> GetNotifications(
			NotificationsSpecification specification,
			CancellationToken cancellationToken = default);
	}
}