using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class StudentIndexViewModel
    {
        public IEnumerable<Student> Students { get; set; } = new List<Student>();
        // EditStudent can be null when no student is being edited
        public Student? EditStudent { get; set; } = new Student();
    }
}
