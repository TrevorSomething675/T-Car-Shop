using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.PresonalNotificationQueries
{
	public class GetPersonalNotificationsQuery(GetPersonalNotificationsFilterModel filter) : IRequest<Result<PagedData<UserNotification>>>
	{
		public GetPersonalNotificationsFilterModel Filter { get; set; } = filter;
	}
}