using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CapgeminiContext _context;

        public StudentRepository(CapgeminiContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync(string? q = null)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(q))
                query = query.Where(s => s.FullName.Contains(q));

            return await query.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            student.Status = "Active";
            student.CreatedAt = DateTime.Now;

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EmailExistsAsync(string email, int? ignoreStudentId = null)
        {
            return await _context.Students
                .AnyAsync(s => s.Email == email &&
                               (!ignoreStudentId.HasValue || s.StudentId != ignoreStudentId));
        }
    }
}