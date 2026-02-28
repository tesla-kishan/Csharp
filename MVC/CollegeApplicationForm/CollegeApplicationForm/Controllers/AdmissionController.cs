using CollegeApplicationForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CollegeApplicationForm.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly IConfiguration _configuration;

        public AdmissionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        // VIEW ALL APPLICATIONS
        public IActionResult Index()
        {
            List<AdmissionForm> list = new List<AdmissionForm>();

            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                string query = "SELECT * FROM AdmissionForms";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new AdmissionForm
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Course = reader["Course"].ToString(),
                        Address = reader["Address"].ToString(),
                        Marks12th = Convert.ToInt32(reader["Marks12th"]),
                        DOB = Convert.ToDateTime(reader["DOB"])
                    });
                }
            }

            return View(list);
        }

        // SHOW FORM
        public IActionResult Apply()
        {
            return View();
        }

        // SUBMIT FORM
        [HttpPost]
        public IActionResult Apply(AdmissionForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                string query = @"INSERT INTO AdmissionForms 
                                (FullName, Email, Phone, Gender, Course, Address, Marks12th, DOB)
                                VALUES
                                (@FullName, @Email, @Phone, @Gender, @Course, @Address, @Marks12th, @DOB)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FullName", form.FullName);
                cmd.Parameters.AddWithValue("@Email", form.Email);
                cmd.Parameters.AddWithValue("@Phone", form.Phone);
                cmd.Parameters.AddWithValue("@Gender", form.Gender);
                cmd.Parameters.AddWithValue("@Course", form.Course);
                cmd.Parameters.AddWithValue("@Address", form.Address);
                cmd.Parameters.AddWithValue("@Marks12th", form.Marks12th);
                cmd.Parameters.AddWithValue("@DOB", form.DOB);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                string query = "DELETE FROM AdmissionForms WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}