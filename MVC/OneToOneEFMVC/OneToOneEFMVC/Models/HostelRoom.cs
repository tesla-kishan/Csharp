using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToOneEFMVC.Models
{
    public class HostelRoom
    {
        [Key]
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public int StudentId { get; set; }

        public Student ResidentStudent { get; set; }
    }
}