namespace T_Car_Shop.Core.Filters
{
	public class GetPersonalNotificationsFilterModel : BaseFilter
	{
		public int PageNumber { get; set; } = 1;
		public Guid UserId { get; set; }
	}
}