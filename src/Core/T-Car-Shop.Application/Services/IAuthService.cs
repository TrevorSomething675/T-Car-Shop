using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Application.Services
{
    public interface IAuthService
    {
        public Task<Result<TokenResponse>> CreateToken(Guid id, string Role, CancellationToken cancellationToken = default);
    }
}