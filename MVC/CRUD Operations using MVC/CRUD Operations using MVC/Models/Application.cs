using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operations_using_MVC.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string ApplicantName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; } = null!;

        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; } = null!;

        [StringLength(4000)]
        public string? ResumeText { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
