namespace T_Car_Shop.Infrastructure.Entities
{
	public class UserNotificationEntity : BaseEntity
	{
		public Guid UserId { get; set; }
		public UserEntity User { get; set; }
		
		public Guid NotificationId { get; set; }
		public NotificationEntity Notification { get; set; }

		public DateTime CreatedDate { get; set; }
		public bool IsChecked { get; set; }
	}
}