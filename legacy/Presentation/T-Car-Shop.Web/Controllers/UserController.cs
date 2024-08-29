using T_Car_Shop.Infrastructure.Queries.UserQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace T_Car_Shop.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] Guid userId, CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(new GetUserQuery(userId), cancellationToken)).ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(new GetUsersQuery(), cancellationToken)).ToActionResult();
        }
    }
}