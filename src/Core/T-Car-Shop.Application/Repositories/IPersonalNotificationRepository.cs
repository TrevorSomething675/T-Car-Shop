using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Repositories
{
	public interface IPersonalNotificationRepository
	{
		Task<PagedData<UserNotificationEntity>> GetAllAsync(PersonalNotificationsSpecification specification, CancellationToken cancellationToken = default);
		Task<UserNotificationEntity> UpdateAsync(UserNotificationEntity userNotification, CancellationToken cancellationToken = default);
	}
}
