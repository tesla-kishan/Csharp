using Microsoft.AspNetCore.Mvc;
using StudentMarksAPI.DTO;
using StudentMarksAPI.Services;

namespace StudentMarksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // CREATE STUDENT + HOSTEL
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentHostelDto dto)
        {
            await _service.CreateStudent(dto);

            return Ok("Student Created With Hostel");
        }

        // GET ALL COLLEGE STUDENTS
        [HttpGet("college-students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var data = await _service.GetAllStudents();

            return Ok(data);
        }

        // GET HOSTEL STUDENTS
        [HttpGet("hostel-students")]
        public async Task<IActionResult> GetHostelStudents()
        {
            var data = await _service.GetAllHostelStudents();

            return Ok(data);
        }

        // UPDATE STUDENT INFO
        [HttpPut("update-student/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentHostelDto dto)
        {
            await _service.UpdateStudent(id, dto);

            return Ok("Student Updated");
        }

        // UPDATE ROOM NUMBER
        [HttpPut("update-room")]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto dto)
        {
            await _service.UpdateRoomNumber(dto);

            return Ok("Room Updated Successfully");
        }

        // DELETE STUDENT
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _service.DeleteStudent(id);

            return Ok("Student Deleted");
        }
    }
}