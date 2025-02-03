namespace T_Car_Shop.Domain.Models
{
	public class Notification : BaseModel
	{
		public string Header { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }

		public List<UserNotification>? UserNotification { get; set; }
	}
}