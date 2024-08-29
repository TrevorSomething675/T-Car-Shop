using T_Car_Shop.Infrastructure.Commands.AccountCommands;
using T_Car_Shop.Core.Models.Web.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace T_Car_Shop.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IMediator _mediator;
		public AccountController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> UpdateUserData([FromForm] AccountUserRequest accountUserData, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new UpdateAccountDataCommand(accountUserData), cancellationToken)).ToActionResult();
		}
	}
}