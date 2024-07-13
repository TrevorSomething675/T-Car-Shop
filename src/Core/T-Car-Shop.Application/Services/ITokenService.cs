namespace T_Car_Shop.Application.Services
{
    public interface ITokenService
    {
        Task<string> CreateAccessToken(Guid id, string role);
        Task<string> CreateRefreshToken();
    }
}