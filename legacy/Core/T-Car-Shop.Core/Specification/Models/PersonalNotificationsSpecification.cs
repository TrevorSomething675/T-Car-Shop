using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Filters;

namespace T_Car_Shop.Core.Specification.Models
{
	public class PersonalNotificationsSpecification : BaseSpecification<UserNotificationEntity>
	{
		public PersonalNotificationsSpecification(GetPersonalNotificationsFilterModel filter) 
		{
			PageNumber = filter.PageNumber;
			AddFilter(p => p.UserId == filter.UserId);
			AddIncludes(filter.Includes);
			AddOrderBy(filter.SortField);
		}
	}
}