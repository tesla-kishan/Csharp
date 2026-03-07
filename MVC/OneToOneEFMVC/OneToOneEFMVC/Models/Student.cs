using System.ComponentModel.DataAnnotations;

namespace OneToOneEFMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }   // ← ADD THIS

        public string City { get; set; }

        // One Student → One Room
        public HostelRoom AssignedRoom { get; set; }
    }
}