using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructor _instructorRepository;

        public InstructorController(IInstructor instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        [HttpPost("AddInstructor")]
        public IActionResult AddInstructor([FromBody] Instructor instructor)
        {
            var result = _instructorRepository.AddInstructor(instructor);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("WithCourseCountAbove/{count}")]
        public IActionResult WithCourseCountAbove(int count)
        {
            var instructors = _instructorRepository.GetInstructorsWithCourseCountAbove(count);
            if (instructors == null || !instructors.Any())
            {
                return NotFound("No Records Found.");
            }
            return Ok(instructors);
        }

        [HttpGet("WithMostEnrollments")]
        public IActionResult WithMostEnrollments()
        {
            var instructors = _instructorRepository.GetInstructorsWithMostEnrollments();
            if (instructors == null || !instructors.Any())
            {
                return NotFound("No Records Found.");
            }
            return Ok(instructors);
        }
    }
}
