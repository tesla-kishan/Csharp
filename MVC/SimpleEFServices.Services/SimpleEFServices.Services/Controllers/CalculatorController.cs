using Microsoft.AspNetCore.Mvc;
using SimpleEFServices.Services;

namespace SimpleEFServices.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            int result = _calculatorService.Add(10, 5);

            ViewBag.Result = result;

            return View("~/Views/Home/Index.cshtml");
        }
    }
}