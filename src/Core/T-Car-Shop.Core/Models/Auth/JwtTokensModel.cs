namespace T_Car_Shop.Core.Models.Auth
{
	public class JwtTokensModel
	{
		public JwtTokensModel(string accessToken, string refreshToken) 
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}
		public string AccessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
	}
}