using T_Car_Shop.Core.Models.Auth;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.AuthCommands
{
	public class RegisterCommand(RegisterFormModel formData) : IRequest<Result<JwtTokensModel>>
	{
		public RegisterFormModel FormData { get; set; } = formData;
	}
}