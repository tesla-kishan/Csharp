using OneToOneEFMVC.Models;
using OneToOneEFMVC.Data;
using OneToOneEFMVC.Models;

namespace OneToOneEFMVC.Services
{
    public class StudentService
    {
        private readonly StudentManagementContext _context;

        public StudentService(StudentManagementContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }
    }
}