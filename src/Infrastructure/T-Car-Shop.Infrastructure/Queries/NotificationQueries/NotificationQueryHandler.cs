using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.NotificationQueries
{
	public class NotificationQueryHandler : IRequestHandler<NotificationQuery, Result<PagedData<Notification>>>
	{
		private readonly INotificationService _notificationService;
		public NotificationQueryHandler(INotificationService notificationService) 
		{
			_notificationService = notificationService;
		}
		public async Task<Result<PagedData<Notification>>> Handle(NotificationQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var specification = new NotificationsSpecification(request.Filter);
				var notifications = await _notificationService.GetNotifications(specification, cancellationToken);

				return new Result<PagedData<Notification>>(notifications).Success();
			}
			catch (NotFoundException ex)
			{
				return new Result<PagedData<Notification>>().NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return new Result<PagedData<Notification>>().BadRequest(ex.Message);
			}
		}
	}
}