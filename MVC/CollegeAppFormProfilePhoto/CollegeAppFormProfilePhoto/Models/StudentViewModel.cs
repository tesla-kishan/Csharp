using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CollegeAppFormProfilePhoto.Models
{
    public class StudentViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name must contain only letters.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name must contain only letters.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Surname must contain only letters.")]
        public string SurName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(StudentViewModel), nameof(ValidateDOB))]
        public DateTime DOB { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "12th percentage must be between 0 and 100.")]
        public double TwelfthPercentage { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Father's name must contain only letters.")]
        public string FatherName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Profile photo is required.")]
        public IFormFile ProfilePhoto { get; set; }

        public static ValidationResult ValidateDOB(DateTime dob, ValidationContext context)
        {
            if (dob > DateTime.Now)
            {
                return new ValidationResult("DOB cannot be in the future.");
            }

            int age = DateTime.Now.Year - dob.Year;
            if (age < 16)
            {
                return new ValidationResult("Student must be at least 16 years old.");
            }

            return ValidationResult.Success;
        }
    }
}