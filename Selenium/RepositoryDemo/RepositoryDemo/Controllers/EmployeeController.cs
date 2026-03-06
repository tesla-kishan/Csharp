using Microsoft.AspNetCore.Mvc;
using RepositoryDemo.Models;
using RepositoryDemo.Repositories;

namespace RepositoryDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var employees = _repo.GetAll();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            _repo.Add(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}