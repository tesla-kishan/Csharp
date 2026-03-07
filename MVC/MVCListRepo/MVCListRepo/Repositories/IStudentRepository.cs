using MVCListRepo.Models;
using System.Collections.Generic;

namespace MVCListRepo.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
    }
}