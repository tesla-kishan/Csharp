using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class InstructorRepository : IInstructor
    {
        private readonly UniversityContext _context;

        public InstructorRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool AddInstructor(Instructor instructor)
        {
            var existingInstructor = _context.Instructors.Find(instructor.InstructorId);
            if (existingInstructor != null)
            {
                return false;
            }
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Instructor> GetInstructorsWithCourseCountAbove(int count)
        {
            var instructors = _context.InstructorCourses
                .GroupBy(ic => ic.InstructorId)
                .Where(g => g.Count() > count)
                .Select(g => g.First().Instructor)
                .ToList();
            return instructors;
        }

        public IEnumerable<Instructor> GetInstructorsWithMostEnrollments()
        {
            var instructorEnrollments = _context.InstructorCourses
                .GroupBy(ic => ic.InstructorId)
                .Select(g => new
                {
                    InstructorId = g.Key,
                    TotalEnrollments = g.Sum(ic => ic.Course.Enrollments.Count())
                })
                .ToList();

            if (!instructorEnrollments.Any())
            {
                return new List<Instructor>();
            }

            var maxEnrollments = instructorEnrollments.Max(x => x.TotalEnrollments);

            var topInstructorIds = instructorEnrollments
                .Where(x => x.TotalEnrollments == maxEnrollments)
                .Select(x => x.InstructorId)
                .ToList();

            var instructors = _context.Instructors
                .Where(i => topInstructorIds.Contains(i.InstructorId))
                .ToList();

            return instructors;
        }
    }
}
