using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===============================
        // Create Student (Using URL)
        // ===============================
        public IActionResult Create(string name, float age, string city)
        {
            var student = new Student
            {
                Name = name,
                Age = age,
                City = city
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return Content("Student Created Successfully");
        }

        // ===============================
        // Show All Students
        // ===============================
        public IActionResult All()
        {
            var students = _context.Students.ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var s in students)
            {
                sb.Append($"{s.Id} - {s.Name} - {s.Age} - {s.City} <br>");
            }

            return Content(sb.ToString(), "text/html");
        }

        // ===============================
        // Get Student By ID
        // ===============================
        // Example: /Students/Details/1
        public IActionResult Details(int id)
        {
            var s = _context.Students.Find(id);

            if (s == null)
                return Content("Student not found");

            return Content($"{s.Id} - {s.Name} - {s.Age} - {s.City}");
        }
    }
}