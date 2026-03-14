using Microsoft.AspNetCore.Mvc;
using FilterDemo.Filters;

namespace FilterDemo.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {

        [HttpGet]
        [LoggingFilter]  // Action Filter
        public IActionResult GetData()
        {
            return Ok("Hello from Logging Filter");
        }


        [HttpGet("secure")]
        [CustomAuthorization]  // Authorization Filter
        public IActionResult SecureData()
        {
            return Ok("Authorized Access");
        }
    }
}