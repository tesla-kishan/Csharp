using Microsoft.AspNetCore.Mvc;
using CollegeAppFormProfilePhoto.Models;
using Microsoft.Data.SqlClient;
using SixLabors.ImageSharp;
using System.IO;
using System.Linq;

namespace CollegeAppFormProfilePhoto.Controllers
{
    public class StudentController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public StudentController(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        // =======================
        // GET
        // =======================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // =======================
        // POST
        // =======================
        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(model.ProfilePhoto.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("ProfilePhoto", "Only JPG and PNG allowed.");
                return View(model);
            }

            if (model.ProfilePhoto.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ProfilePhoto", "File must be less than 2MB.");
                return View(model);
            }

            // Dimension Check
            using (var image = Image.Load(model.ProfilePhoto.OpenReadStream()))
            {
                if (image.Width < 200 || image.Height < 200)
                {
                    ModelState.AddModelError("ProfilePhoto", "Image must be at least 200x200.");
                    return View(model);
                }

                if (image.Width > 2000 || image.Height > 2000)
                {
                    ModelState.AddModelError("ProfilePhoto", "Image must not exceed 2000x2000.");
                    return View(model);
                }
            }

            // Save Image
            string uploadPath = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string fileName = Guid.NewGuid().ToString() + extension;
            string filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.ProfilePhoto.CopyTo(stream);
            }

            // Insert into DB
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                string query = @"INSERT INTO Students
                (FirstName, LastName, SurName, DOB, TwelfthPercentage, FatherName, PhoneNumber, Email, PhotoPath)
                VALUES
                (@FirstName, @LastName, @SurName, @DOB, @TwelfthPercentage, @FatherName, @PhoneNumber, @Email, @PhotoPath)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@SurName", model.SurName);
                cmd.Parameters.AddWithValue("@DOB", model.DOB);
                cmd.Parameters.AddWithValue("@TwelfthPercentage", model.TwelfthPercentage);
                cmd.Parameters.AddWithValue("@FatherName", model.FatherName);
                cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@PhotoPath", "/uploads/" + fileName);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult List()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new StudentViewModel
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        SurName = reader["SurName"].ToString(),
                        FatherName = reader["FatherName"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        TwelfthPercentage = Convert.ToDouble(reader["TwelfthPercentage"]),
                        DOB = Convert.ToDateTime(reader["DOB"])
                    });
                }
            }

            return View(students);
        }
    }
}