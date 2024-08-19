using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.Auth;

namespace T_Car_Shop.Application.Services
{
	public interface IAccountService
	{
		Task<AuthModel> LoginAsync(User user, CancellationToken cancellationToken = default);
		Task<AuthModel> RegisterAsync(User user, CancellationToken cancellationToken = default);
		Task<User> UpdateAccountDataAsync(User user, CancellationToken cancellationToken = default);
	}
}