using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DownloadMVC.Models
{
    public class CollegeApplication
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression("^[a-zA-Z]+$",
            ErrorMessage = "First Name should contain only letters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression("^[a-zA-Z]+$",
            ErrorMessage = "Last Name should contain only letters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [RegularExpression("^[a-zA-Z]+$",
            ErrorMessage = "Surname should contain only letters.")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(CollegeApplication), nameof(ValidateAge))]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "12th Percentage is required.")]
        [Range(0, 100,
            ErrorMessage = "Percentage must be between 0 and 100.")]
        public double TwelfthPercentage { get; set; }

        [Required(ErrorMessage = "Father Name is required.")]
        [RegularExpression("^[a-zA-Z ]+$",
            ErrorMessage = "Father Name should contain only letters.")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        public string? PhotoPath { get; set; }
        public string? ApplicationPdfPath { get; set; }

        [Required(ErrorMessage = "Profile photo is required.")]
        public IFormFile ProfilePhoto { get; set; }

        // ✅ AGE VALIDATION METHOD
        public static ValidationResult ValidateAge(DateTime dob, ValidationContext context)
        {
            int age = DateTime.Now.Year - dob.Year;

            if (dob > DateTime.Now)
                return new ValidationResult("Date of Birth cannot be in future.");

            if (age < 16)
                return new ValidationResult("Student must be at least 16 years old.");

            return ValidationResult.Success;
        }
    }
}