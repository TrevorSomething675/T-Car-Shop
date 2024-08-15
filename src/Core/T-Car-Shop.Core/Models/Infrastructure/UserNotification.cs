namespace T_Car_Shop.Core.Models.Infrastructure
{
	public class UserNotification : BaseModel
	{
		public Guid UserId { get; set; }
		public User? User { get; set; }

		public Guid NotificationId { get; set; }
		public Notification? Notification { get; set; }

		public DateTime CreatedDate { get; set; }
		public bool IsChecked { get; set; }
	}
}