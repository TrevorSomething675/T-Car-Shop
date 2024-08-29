using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.PersonalNotificationCommands
{
	public class UpdatePersonalNotification(UserNotification user) : IRequest<Result<UserNotification>>
	{
		public UserNotification User { get; set; } = user;
	}
}