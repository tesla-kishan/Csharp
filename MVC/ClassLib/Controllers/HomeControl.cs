// using Microsoft.AspNetCore.Mvc;

// namespace ClassLib.Controllers;

// public class HomeController : Controller
// {
//     public IActionResult Index()
//     {
//         return View();
//     }

//     public IActionResult Student()
//     {
//         var s = new { Name = "Kishan", Age = 22 };
//         return Json(s);
//     }

//     public IActionResult Test()
//     {
//         return NotFound();
//     }

//     public IActionResult Square(int? number)
//     {
//         if (number == null)
//             return Content("Please provide a number");

//         return View(number.Value);
//     }
// }