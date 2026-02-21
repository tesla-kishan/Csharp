using Microsoft.AspNetCore.Mvc;

namespace controllerToView.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Display()
        {
            ViewBag.Name = TempData["Name"];
            ViewBag.College = TempData["College"];

            return View();
        }
    }
}