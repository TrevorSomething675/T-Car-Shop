using T_Car_Shop.Infrastructure.Commands.PersonalNotificationCommands;
using T_Car_Shop.Infrastructure.Queries.PresonalNotificationQueries;
using T_Car_Shop.Core.Models.Web.UserNotification;
using Microsoft.AspNetCore.Mvc;
using T_Car_Shop.Core.Filters;
using MediatR;

namespace T_Car_Shop.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PersonalNotificationController : ControllerBase
	{
		private readonly IMediator _mediator;
		public PersonalNotificationController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetPersonalNotificationsFilterModel filter, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new GetPersonalNotificationsQuery(filter), cancellationToken)).ToActionResult();
		}
		[HttpPost]
		public async Task<IActionResult> Update([FromBody] UserNotificationRequest user, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new UpdatePersonalNotification(user), cancellationToken)).ToActionResult();
		}
	}
}