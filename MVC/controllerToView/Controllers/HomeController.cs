using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using controllerToView.Models;

namespace controllerToView.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SendData()
    {
        TempData["Name"] = "Kishan ";
        TempData["College"] = "Lovely Professional University";

        return RedirectToAction("Display", "View");
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