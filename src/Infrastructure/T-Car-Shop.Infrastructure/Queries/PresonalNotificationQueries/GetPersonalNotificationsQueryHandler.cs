using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.PresonalNotificationQueries
{
	public class GetPersonalNotificationsQueryHandler : IRequestHandler<GetPersonalNotificationsQuery, Result<PagedData<UserNotification>>>
	{
		private readonly IPersonalNotificationService _personalNotificationService;

		public GetPersonalNotificationsQueryHandler(IPersonalNotificationService personalNotificationService)
		{
			_personalNotificationService = personalNotificationService;
		}
		public async Task<Result<PagedData<UserNotification>>> Handle(GetPersonalNotificationsQuery request, CancellationToken cancellationToken)
		{
			var specification = new PersonalNotificationsSpecification(request.Filter);

			var personalNotifications = await _personalNotificationService.GetAllAsync(specification, cancellationToken);

			return new Result<PagedData<UserNotification>>(personalNotifications);
		}
	}
}