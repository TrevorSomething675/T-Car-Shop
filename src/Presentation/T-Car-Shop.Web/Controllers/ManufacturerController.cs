using T_Car_Shop.Infrastructure.Queries.ManufacturerQueries;
using Microsoft.AspNetCore.Mvc;
using T_Car_Shop.Core.Filters;
using MediatR;

namespace T_Car_Shop.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ManufacturerController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ManufacturerController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetManufacturersFilterModel filter, CancellationToken cancellationToken = default)
		{
			return (await _mediator.Send(new GetManufacturersQuery(filter), cancellationToken)).ToActionResult();
		}

		[HttpPost]
		public async Task<IActionResult> Create()
		{
			return BadRequest();
		}
	}
}