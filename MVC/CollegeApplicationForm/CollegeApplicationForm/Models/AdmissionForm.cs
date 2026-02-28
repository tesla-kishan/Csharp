using System.ComponentModel.DataAnnotations;

namespace CollegeApplicationForm.Models
{
    public class AdmissionForm
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Name must contain letters only")]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone must be 10 digits")]
        public string? Phone { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public string? Course { get; set; }

        [Required]
        public string? Address { get; set; }

        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int Marks12th { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(AdmissionForm), "ValidateDOB")]
        public DateTime DOB { get; set; }

        public static ValidationResult? ValidateDOB(DateTime dob, ValidationContext context)
        {
            if (dob > DateTime.Today)
                return new ValidationResult("DOB cannot be future date");

            return ValidationResult.Success;
        }
    }
}