using StudentMarksAPI.DTO;
using StudentMarksWebAPI.Models;

namespace StudentMarksAPI.Services
{
    public interface IStudentService
    {
        Task CreateStudent(StudentHostelDto dto);

        Task<List<Student>> GetAllStudents();

        Task<List<Hostel>> GetAllHostelStudents();

        Task UpdateStudent(int id, StudentHostelDto dto);

        Task UpdateRoomNumber(UpdateRoomDto dto);

        Task DeleteStudent(int id);
    }
}