using T_Car_Shop.Core.Models.Auth;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.AuthCommands
{
	public class LoginCommand(LoginFormModel formData) : IRequest<Result<AuthModel>>
	{
		public LoginFormModel FormData { get; set; } = formData;
	}
}