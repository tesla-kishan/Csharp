using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentRepository;

        public StudentController(IStudent studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpDelete("DeleteStudent/{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            var result = _studentRepository.DeleteStudent(studentId);
            if (result)
            {
                return Ok();
            }
            return NotFound("No Records Found.");
        }

        [HttpGet("ByCourseTitle/{courseTitle}")]
        public IActionResult ByCourseTitle(string courseTitle)
        {
            var students = _studentRepository.GetStudentsByCourseTitle(courseTitle);
            if (students == null || !students.Any())
            {
                return NotFound("No Records Found.");
            }
            return Ok(students);
        }
    }
}
