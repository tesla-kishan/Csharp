using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class StudentDetailsViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
