using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.Auth;

namespace T_Car_Shop.Application.Services
{
	public interface IAccountService
	{
		Task<AuthModel> Login(User user, CancellationToken cancellationToken = default);
		Task<AuthModel> Register(User user, CancellationToken cancellationToken = default);
	}
}