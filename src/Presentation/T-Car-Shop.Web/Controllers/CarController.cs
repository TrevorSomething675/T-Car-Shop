using T_Car_Shop.Infrastructure.Commands.CarCommands;
using T_Car_Shop.Infrastructure.Queries.CarQueries;
using T_Car_Shop.Core.DomainModels;
using Microsoft.AspNetCore.Mvc;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IResult<Car>>> Get(CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(new GetCarsQuery(), cancellationToken)).ToActionResult();
            
        }

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            return Ok("jija");
        }

        [HttpDelete]
        public async Task<Result<Guid>> Remove([FromQuery] Guid carId, CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(new RemoveCarCommand(carId), cancellationToken))).ToActionResult()
        }

        [HttpPut]
        public async Task<ActionResult> Update()
        {
            return Ok("jija");
        }
    }
}