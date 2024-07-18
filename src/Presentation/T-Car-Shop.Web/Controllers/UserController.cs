using T_Car_Shop.Infrastructure.Queries.UserQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace T_Car_Shop.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(new GetUsersQuery(), cancellationToken)).ToActionResult();
        }
    }
}