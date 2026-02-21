using Microsoft.AspNetCore.Mvc;

namespace ContollerToController.controllers{
public class StudentController : Controller
{
public IActionResult Receive()
{
    var msg = TempData["Message"];
    return Content(msg?.ToString());
}
public IActionResult Index()
{
    return View();
}

}
}