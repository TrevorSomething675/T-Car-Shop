﻿using T_Car_Shop.Infrastructure.Commands.CarCommands;
using T_Car_Shop.Infrastructure.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;
using T_Car_Shop.Core.Filters;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetCarFilterModel filter, CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(new GetCarQuery(filter), cancellationToken)).ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCarsFilterModel filter, CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(new GetCarsQuery(filter), cancellationToken)).ToActionResult();
        }
		[HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateCarCommand command, CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(command, cancellationToken)).ToActionResult();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid carId, CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(new RemoveCarCommand(carId), cancellationToken)).ToActionResult();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateCarCommand command, CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(command, cancellationToken)).ToActionResult();
        }
    }
}