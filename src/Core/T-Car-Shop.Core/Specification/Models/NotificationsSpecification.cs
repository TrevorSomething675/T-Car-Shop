using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Filters;

namespace T_Car_Shop.Core.Specification.Models
{
	public class NotificationsSpecification : BaseSpecification<NotificationEntity>
	{
		public NotificationsSpecification(GetNotificationsFilterModel filter)
		{
			PageNumber = filter.PageNumber;
			AddIncludes(filter.Includes);
			AddOrderBy(filter.SortField);
		}
	}
}