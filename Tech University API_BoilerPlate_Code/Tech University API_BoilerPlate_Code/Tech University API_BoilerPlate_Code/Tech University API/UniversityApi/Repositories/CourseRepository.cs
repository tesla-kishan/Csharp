using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityApi.Repositories
{
    public class CourseRepository : ICourse
    {
        private readonly UniversityContext _context;

        public CourseRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool UpdateCourse(Course course)
        {
            var existingCourse = _context.Courses.Find(course.CourseId);
            if (existingCourse == null)
            {
                return false;
            }
            existingCourse.Title = course.Title;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Course> GetCoursesWithEnrollmentsAboveGrade(int grade)
        {
            var courses = _context.Courses
                .Where(c => c.Enrollments.Any(e => e.Grade > grade))
                .ToList();
            return courses;
        }

        public IEnumerable<Course> GetCoursesByInstructorName(string instructorName)
        {
            var courses = _context.InstructorCourses
                .Where(ic => ic.Instructor.Name == instructorName)
                .Select(ic => ic.Course)
                .ToList();
            return courses;
        }

        public Course GetCourseByIdWithDetails(int courseId)
        {
            var course = _context.Courses
                .Where(c => c.CourseId == courseId)
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .Include(c => c.InstructorCourses)
                .ThenInclude(ic => ic.Instructor)
                .FirstOrDefault();
            return course;
        }
    }
}
