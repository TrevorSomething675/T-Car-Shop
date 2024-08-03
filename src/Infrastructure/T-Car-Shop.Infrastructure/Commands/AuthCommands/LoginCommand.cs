using T_Car_Shop.Core.Shared;
using MediatR;
using T_Car_Shop.Core.Models.Web.Auth;

namespace T_Car_Shop.Infrastructure.Commands.AuthCommands
{
    public class LoginCommand(LoginFormModel formData) : IRequest<Result<AuthModel>>
	{
		public LoginFormModel FormData { get; set; } = formData;
	}
}