using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToSquare.Models;

namespace ToSquare.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Send(int number)
    {
        TempData["Number"] = number;
        return RedirectToAction("Receive", "Student");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel 
        { 
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
        });
    }
}