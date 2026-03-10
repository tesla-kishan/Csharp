using Microsoft.AspNetCore.Mvc;

namespace Add3Num.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SumController : ControllerBase
    {
        [HttpGet]
        public int AddNumbers()
        {
            int a = 3;
            int b = 4;
            int c = 5;

            int result = a + b + c;

            return result;
        }
    }
}