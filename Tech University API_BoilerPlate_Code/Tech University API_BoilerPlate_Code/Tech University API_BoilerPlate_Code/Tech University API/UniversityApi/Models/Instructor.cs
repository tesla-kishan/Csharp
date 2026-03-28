using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityApi.Models
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstructorId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<InstructorCourse>? InstructorCourses { get; set; }
    }
}
