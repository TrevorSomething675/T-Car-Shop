namespace T_Car_Shop.Core.Filters
{
	public class GetNotificationsFilterModel : BaseFilter
	{
		public Guid UserId { get; set; }
		public int PageNumber { get; set; }
	}
}