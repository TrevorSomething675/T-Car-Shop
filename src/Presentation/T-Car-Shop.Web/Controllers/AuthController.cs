using T_Car_Shop.Infrastructure.Commands.AuthCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using T_Car_Shop.Core.Models.Web.Auth;

namespace T_Car_Shop.Web.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;
		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromForm] LoginFormModel formData, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new LoginCommand(formData), cancellationToken)).ToActionResult();
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromForm] RegisterFormModel formData, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new RegisterCommand(formData), cancellationToken)).ToActionResult();
		}
	}
}