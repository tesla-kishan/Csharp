using Microsoft.EntityFrameworkCore;
using StudentMarksAPI.DTO;
using StudentMarksWebAPI.Models;

namespace StudentMarksAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly CollegeDbContext _context;

        public StudentService(CollegeDbContext context)
        {
            _context = context;
        }

        // CREATE STUDENT + HOSTEL
        public async Task CreateStudent(StudentHostelDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                Course = dto.Course
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var hostel = new Hostel
            {
                RoomNumber = dto.RoomNumber,
                RoomType = dto.RoomType,
                StudentId = student.StudentId
            };

            _context.Hostels.Add(hostel);
            await _context.SaveChangesAsync();
        }

        // GET ALL COLLEGE STUDENTS
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET ALL HOSTEL STUDENTS
        public async Task<List<Hostel>> GetAllHostelStudents()
        {
            return await _context.Hostels
                .Include(h => h.Student)
                .ToListAsync();
        }

        // UPDATE STUDENT INFORMATION
        public async Task UpdateStudent(int id, StudentHostelDto dto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null) return;

            student.Name = dto.Name;
            student.Age = dto.Age;
            student.Course = dto.Course;

            await _context.SaveChangesAsync();
        }

        // UPDATE ROOM NUMBER
        public async Task UpdateRoomNumber(UpdateRoomDto dto)
        {
            var hostel = await _context.Hostels
                .FirstOrDefaultAsync(h => h.StudentId == dto.StudentId);

            if (hostel == null) return;

            hostel.RoomNumber = dto.RoomNumber;
            hostel.RoomType = dto.RoomType;

            await _context.SaveChangesAsync();
        }

        // DELETE STUDENT
        public async Task DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null) return;

            var hostel = await _context.Hostels
                .FirstOrDefaultAsync(h => h.StudentId == id);

            if (hostel != null)
                _context.Hostels.Remove(hostel);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
        }
    }
}