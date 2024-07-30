using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Auth;

namespace T_Car_Shop.Application.Services
{
	public interface IUserService
	{
		Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
		public Task<JwtTokensModel> Login(User user, CancellationToken cancellationToken = default);
		public Task<JwtTokensModel> Register(User user, CancellationToken cancellationToken = default);
	}
}