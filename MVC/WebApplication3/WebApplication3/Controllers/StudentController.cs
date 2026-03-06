using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index(int page = 1)
        {
            List<Student> students = new List<Student>();

            string cs = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetStudentsPaged", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PageNumber", page);
                cmd.Parameters.AddWithValue("@PageSize", 10);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Age = Convert.ToInt32(dr["Age"]),
                        City = dr["City"].ToString()
                    });
                }
            }

            return View(students);
        }
    }
}