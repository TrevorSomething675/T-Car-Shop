using T_Car_Shop.Infrastructure.Commands.UserCarCommand;
using T_Car_Shop.Core.Models.Web.UserCar;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace T_Car_Shop.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PersonalCarController : ControllerBase
	{
		private readonly IMediator _mediator;
		public PersonalCarController(IMediator mediator) 
		{
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] UserCarRequest request, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new CreateUserCarCommand(request), cancellationToken)).ToActionResult();
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromQuery] UserCarRequest request, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new ChangeFavoriteCarCommand(request), cancellationToken)).ToActionResult();
		}
		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] UserCarRequest request, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new DeleteUserCarCommand(request), cancellationToken)).ToActionResult();
		}
	}
}