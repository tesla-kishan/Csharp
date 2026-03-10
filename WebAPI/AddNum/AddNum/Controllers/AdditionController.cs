using Microsoft.AspNetCore.Mvc;

namespace AddNum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdditionController : Controller
    {
        [HttpGet("add")]
        public IActionResult AddNumbers(int a, int b, int c)
        {
            // check range
            if (a < 1 || a > 100 || b < 1 || b > 100 || c < 1 || c > 100)
            {
                return BadRequest("Numbers must be between 1 and 100");
            }

            int sum = a + b + c;

            return Ok("Sum = " + sum);
        }
    }
}
