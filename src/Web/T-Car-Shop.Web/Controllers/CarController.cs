using Microsoft.AspNetCore.Mvc;

namespace T_Car_Shop.Web.Controllers
{
	public class CarController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get(Guid id)
		{
			return Ok();
		}
	}
}