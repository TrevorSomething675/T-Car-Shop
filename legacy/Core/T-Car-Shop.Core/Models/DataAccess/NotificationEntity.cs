namespace T_Car_Shop.Core.Models.DataAccess
{
	public class NotificationEntity : BaseEntity
	{
		public string Header { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }

		public List<UserNotificationEntity>? UserNotification { get; set; }
	}
}