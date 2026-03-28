using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using UniversityApi.Data;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _courseRepository;
        private readonly UniversityContext _context;

        public CourseController(ICourse courseRepository, UniversityContext context)
        {
            _courseRepository = courseRepository;
            _context = context;
        }

        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] Course course)
        {
            var result = _courseRepository.UpdateCourse(course);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("WithEnrollmentsAboveGrade/{grade}")]
        public IActionResult WithEnrollmentsAboveGrade(int grade)
        {
            var courses = _courseRepository.GetCoursesWithEnrollmentsAboveGrade(grade);
            if (courses == null || !courses.Any())
            {
                return NotFound("No Records Found.");
            }
            return Ok(courses);
        }

        [HttpGet("ByInstructorName/{instructorName}")]
        public IActionResult ByInstructorName(string instructorName)
        {
            var courses = _courseRepository.GetCoursesByInstructorName(instructorName);
            if (courses == null || !courses.Any())
            {
                return NotFound("No Records Found.");
            }
            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        public IActionResult GetCourseById(int courseId)
        {
            var course = _courseRepository.GetCourseByIdWithDetails(courseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            return Ok(course);
        }
    }
}
