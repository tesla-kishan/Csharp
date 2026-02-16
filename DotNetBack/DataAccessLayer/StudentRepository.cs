using System.Collections.Generic;

namespace DataAccessLayer
{
    public class StudentRepository
    {
        public List<string> GetStudents()
        {
            return new List<string>
            {
                "Kishan",
                "Rahul",
                "Amit",
                "Neha",
                "Priya",
                "Rohan",
                "Anjali",
                "Vikas",
                "Sneha",
                "Arjun"
            };
        }
    }
}