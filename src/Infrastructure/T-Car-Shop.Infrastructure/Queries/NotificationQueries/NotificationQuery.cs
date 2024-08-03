using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.NotificationQueries
{
	public class NotificationQuery(GetNotificationsFilterModel filter) : IRequest<Result<PagedData<Notification>>>
	{
		public GetNotificationsFilterModel Filter { get; set; } = filter;
	}
}