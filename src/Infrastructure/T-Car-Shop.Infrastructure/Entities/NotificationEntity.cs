namespace T_Car_Shop.Infrastructure.Entities
{
	public class NotificationEntity : BaseEntity
	{
		public string Header { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }

		public List<UserNotificationEntity>? UserNotification { get; set; }
	}
}