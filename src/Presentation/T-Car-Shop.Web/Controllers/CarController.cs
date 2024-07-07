using Microsoft.AspNetCore.Mvc;

namespace T_Car_Shop.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("jija");
        }

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            return Ok("jija");
        }

        [HttpDelete]
        public async Task<ActionResult> Remove()
        {
            return Ok("jija");
        }

        [HttpPut]
        public async Task<ActionResult> Update()
        {
            return Ok("jija");
        }
    }
}