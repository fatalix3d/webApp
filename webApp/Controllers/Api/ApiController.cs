using Microsoft.AspNetCore.Mvc;

namespace webApp.Controllers.Api
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok("Hello from API");
        }
    }
}
