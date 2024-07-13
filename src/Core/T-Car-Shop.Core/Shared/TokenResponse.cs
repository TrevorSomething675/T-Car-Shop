namespace T_Car_Shop.Core.Shared
{
    public class TokenResponse
    {
        public TokenResponse(string accessToken, string refreshToken)
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
        }
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}