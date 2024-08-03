using System.Text.Json.Serialization;

namespace T_Car_Shop.Core.Models.Infrastructure
{
	public class Notification : BaseModel
	{
		public string Header { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }
		[JsonIgnore]
		public List<UserNotification>? UserNotification { get; set; }
	}
}