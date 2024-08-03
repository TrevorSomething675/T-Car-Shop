using T_Car_Shop.Core.Models.Web.UserNotification;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.PersonalNotificationCommands
{
	public class UpdatePersonalNotification(UserNotificationRequest user) : IRequest<Result<UserNotification>>
	{
		public UserNotificationRequest User { get; set; } = user;
	}
}