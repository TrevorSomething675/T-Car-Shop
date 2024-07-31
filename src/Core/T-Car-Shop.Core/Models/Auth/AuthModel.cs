using T_Car_Shop.Core.Models.Infrastructure;

namespace T_Car_Shop.Core.Models.Auth
{
	public class AuthModel
	{
		public AuthModel(string accessToken, string refreshToken, User user)
		{
			User = user;
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}
		public AuthModel(string accessToken, string refreshToken) 
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}
		public string AccessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
		public User User { get; set; }
	}
}