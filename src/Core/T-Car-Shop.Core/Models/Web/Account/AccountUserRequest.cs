using T_Car_Shop.Core.Models.Infrastructure;

namespace T_Car_Shop.Core.Models.Web.Account
{
	public class AccountUserRequest : BaseModel
	{
		public string? UserName { get; set; }
		public string? NewUserName { get; set; }
		public string? Password { get; set; }
		public string? NewPassword { get; set; }
		public string? ConfirmNewPassword { get; set; }
	}
}