using T_Car_Shop.Core.Models.Web.Notification;

namespace T_Car_Shop.Core.Models.Web.UserNotification
{
	public class UserNotificationRequest
	{ 
		public Guid Id { get; set; }

		public Guid UserId { get; set; }
		public Guid NotificationId { get; set; }

		public bool IsChecked { get; set; }
	}
}