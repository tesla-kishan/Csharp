// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using ClassLib.Models;

// namespace ClassLib.Controllers;

// public class HomeController : Controller
// {
//     public IActionResult Index()
//     {
//         return View();
//     }

//     public IActionResult Privacy()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }




using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClassLib.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Student()
        {
            var s = new { Name = "Srikaran", Age = 22, City = "Hyderabad" };
            return Json(s);
        }
        public IActionResult Square(int? number)
        {
            if (number == null)
            {
                return Content("Please provide a number.");
            }
            return View(number.Value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
