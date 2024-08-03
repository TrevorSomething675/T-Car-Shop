using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.Auth;

namespace T_Car_Shop.Application.Services
{
    public interface IUserService
	{
		Task<User> GetByNameAsync(string name, CancellationToken cancellationToken = default);
		Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
		Task<AuthModel> Login(User user, CancellationToken cancellationToken = default);
		Task<AuthModel> Register(User user, CancellationToken cancellationToken = default);
	}
}