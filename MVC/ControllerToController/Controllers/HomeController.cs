using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControllerToController.Models;

namespace ControllerToController.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Send()
    {
        TempData["Message"] = "Hello from Home Controller";
        return RedirectToAction("Receive", "Student");

        // action method name(receive) and controller name(student)
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
