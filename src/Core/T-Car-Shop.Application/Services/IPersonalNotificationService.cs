using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
	public interface IPersonalNotificationService
	{
		Task<PagedData<UserNotification>> GetAllAsync(PersonalNotificationsSpecification specification, CancellationToken cancellationToken = default);
		Task<UserNotification> UpdateAsync(UserNotification userNotification, CancellationToken cancellationToken = default);
	}
}