using Microsoft.AspNetCore.Mvc;
using StudentMarksAPI.Models;
using System.Linq;

namespace StudentMarksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        // GET ALL STUDENTS
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.Select(s => new
            {
                s.Id,
                s.Name,
                s.M1,
                s.M2,
                Total = (s.M1 ?? 0) + (s.M2 ?? 0),
                Grade = CalculateGrade((s.M1 ?? 0) + (s.M2 ?? 0))
            }).ToList();

            return Ok(students);
        }

        // GET STUDENT BY ID
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students
                .Where(s => s.Id == id)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.M1,
                    s.M2,
                    Total = (s.M1 ?? 0) + (s.M2 ?? 0),
                    Grade = CalculateGrade((s.M1 ?? 0) + (s.M2 ?? 0))
                })
                .FirstOrDefault();

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // GRADE CALCULATION
        private static string CalculateGrade(int total)
        {
            if (total >= 180) return "A";
            if (total >= 150) return "B";
            if (total >= 100) return "C";
            return "Fail";
        }
    }
}