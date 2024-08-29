using T_Car_Shop.Core.Shared;
using MediatR;
using T_Car_Shop.Core.Models.Web.Auth;

namespace T_Car_Shop.Infrastructure.Commands.AuthCommands
{
    public class RegisterCommand(RegisterFormModel formData) : IRequest<Result<AuthModel>>
	{
		public RegisterFormModel FormData { get; set; } = formData;
	}
}