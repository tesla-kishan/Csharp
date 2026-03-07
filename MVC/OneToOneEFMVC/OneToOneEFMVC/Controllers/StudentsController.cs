using Microsoft.AspNetCore.Mvc;
using OneToOneEFMVC.Models;
using OneToOneEFMVC.Services;

namespace OneToOneEFMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAllStudents());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, string roomNumber)
        {
            student.AssignedRoom = new HostelRoom
            {
                RoomNumber = roomNumber
            };

            _service.AddStudent(student);

            return RedirectToAction("Index");
        }
    }
}