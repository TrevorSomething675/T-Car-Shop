using T_Car_Shop.Infrastructure.Queries.NotificationQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using T_Car_Shop.Core.Filters;

namespace T_Car_Shop.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly IMediator _mediator;
		public NotificationController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetNotificationsByUserId([FromQuery] GetNotificationsFilterModel filter, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new NotificationQuery(filter), cancellationToken)).ToActionResult();
		}
	}
}