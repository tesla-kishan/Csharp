using Microsoft.AspNetCore.Mvc;

namespace ApiB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("square")]
        public int Square(int number)
        {
            return number * number;
        }

        [HttpGet("cube")]
        public int Cube(int number)
        {
            return number * number * number;
        }
    }
}