using Microsoft.AspNetCore.Mvc;
using StudentDetails.Models;
using StudentDetails.DTO;

namespace StudentDetails.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        static List<Student> students = new List<Student>();


        // POST - Create Student
        [HttpPost]
        public IActionResult CreateStudent(CreateRequestDTO request)
        {
            Student s = new Student
            {
                Id = request.Id,
                Name = request.Name,
                Age = request.Age
            };

            students.Add(s);

            return Ok("Student Created");
        }


        // PUT - Update Marks
        [HttpPut("{id}")]
        public IActionResult UpdateMarks(int id, UpdateRequestDTO request)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            student.M1 = request.M1;
            student.M2 = request.M2;

            return Ok("Marks Updated");
        }


        // GET RESULT BY ID
        [HttpGet("{id}")]
        public IActionResult GetResultById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            int total = student.M1 + student.M2;

            string grade;

            if (total >= 90)
                grade = "A";
            else if (total >= 70)
                grade = "B";
            else if (total >= 50)
                grade = "C";
            else
                grade = "Fail";


            ResponseRequestDTO result = new ResponseRequestDTO
            {
                Id = student.Id,
                Name = student.Name,
                M1 = student.M1,
                M2 = student.M2,
                TotalMarks = total,
                Grade = grade
            };

            return Ok(result);
        }
    }
}