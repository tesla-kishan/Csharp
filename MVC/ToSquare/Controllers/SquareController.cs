using Microsoft.AspNetCore.Mvc;

namespace ToSquare.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Receive()
        {
            if (TempData["Number"] != null)
            {
                int num = Convert.ToInt32(TempData["Number"]);
                int square = num * num;

                return Content($"Number: {num}, Square: {square}");
            }

            return Content("No number received.");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}