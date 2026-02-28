using DownloadMVC.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DownloadMVC.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public ApplicationController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        private string GetConnection()
            => _configuration.GetConnectionString("DefaultConnection");

        // ================= CREATE GET =================
        public IActionResult Create()
        {
            return View();
        }

        // ================= CREATE POST =================
        [HttpPost]
        public IActionResult Create(CollegeApplication model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // ✅ IMAGE VALIDATION (Fix for WEBP crash)
            string extension = Path.GetExtension(model.ProfilePhoto.FileName).ToLower();

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            {
                ModelState.AddModelError("ProfilePhoto",
                    "Only JPG and PNG images are allowed.");
                return View(model);
            }

            // ================= SAVE PHOTO =================
            string uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            string photoName = Guid.NewGuid() + extension;
            string photoPath = Path.Combine(uploadFolder, photoName);

            using (var stream = new FileStream(photoPath, FileMode.Create))
            {
                model.ProfilePhoto.CopyTo(stream);
            }

            string dbPhotoPath = "/uploads/" + photoName;

            // ================= GENERATE APPLICATION PDF =================
            string pdfFolder = Path.Combine(_environment.WebRootPath, "pdf");
            if (!Directory.Exists(pdfFolder))
                Directory.CreateDirectory(pdfFolder);

            string pdfName = Guid.NewGuid() + ".pdf";
            string pdfPath = Path.Combine(pdfFolder, pdfName);

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
            doc.Open();

            doc.Add(new Paragraph("COLLEGE APPLICATION FORM"));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Name: " + model.FirstName + " " + model.LastName));
            doc.Add(new Paragraph("Surname: " + model.SurName));
            doc.Add(new Paragraph("DOB: " + model.DOB.ToShortDateString()));
            doc.Add(new Paragraph("12th Percentage: " + model.TwelfthPercentage));
            doc.Add(new Paragraph("Father Name: " + model.FatherName));
            doc.Add(new Paragraph("Phone: " + model.PhoneNumber));
            doc.Add(new Paragraph("Email: " + model.Email));
            doc.Close();

            string dbPdfPath = "/pdf/" + pdfName;

            // ================= SAVE TO DATABASE =================
            int newId;

            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                string query = @"INSERT INTO CollegeApplications
                                (FirstName,LastName,SurName,DOB,TwelfthPercentage,
                                 FatherName,PhoneNumber,Email,PhotoPath,ApplicationPdfPath)
                                 OUTPUT INSERTED.Id
                                 VALUES
                                (@FirstName,@LastName,@SurName,@DOB,@TwelfthPercentage,
                                 @FatherName,@PhoneNumber,@Email,@PhotoPath,@PdfPath)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@SurName", model.SurName);
                cmd.Parameters.AddWithValue("@DOB", model.DOB);
                cmd.Parameters.AddWithValue("@TwelfthPercentage", model.TwelfthPercentage);
                cmd.Parameters.AddWithValue("@FatherName", model.FatherName);
                cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@PhotoPath", dbPhotoPath);
                cmd.Parameters.AddWithValue("@PdfPath", dbPdfPath);

                con.Open();
                newId = (int)cmd.ExecuteScalar();
            }

            return RedirectToAction("IdCard", new { id = newId });
        }

        // ================= SHOW ID CARD =================
        public IActionResult IdCard(int id)
        {
            CollegeApplication student = GetStudentById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // ================= DOWNLOAD APPLICATION PDF =================
        public IActionResult DownloadPdf(int id)
        {
            var student = GetStudentById(id);

            if (student == null || string.IsNullOrEmpty(student.ApplicationPdfPath))
                return NotFound();

            string fullPath = Path.Combine(_environment.WebRootPath,
                student.ApplicationPdfPath.TrimStart('/'));

            if (!System.IO.File.Exists(fullPath))
                return NotFound();

            return PhysicalFile(fullPath, "application/pdf", "Application.pdf");
        }

        // ================= DOWNLOAD FANCY ID CARD =================
        public IActionResult DownloadIdCard(int id)
        {
            var student = GetStudentById(id);

            if (student == null)
                return NotFound();

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A6);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                PdfPTable table = new PdfPTable(1);
                table.WidthPercentage = 100;

                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = new BaseColor(20, 40, 90);
                cell.Padding = 20;
                cell.Border = 0;

                // Title
                Paragraph title = new Paragraph("COLLEGE ID CARD",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.WHITE));
                title.Alignment = Element.ALIGN_CENTER;
                cell.AddElement(title);

                cell.AddElement(new Paragraph("\n"));

                // Photo
                if (!string.IsNullOrEmpty(student.PhotoPath))
                {
                    string photoFullPath = Path.Combine(_environment.WebRootPath,
                        student.PhotoPath.TrimStart('/'));

                    if (System.IO.File.Exists(photoFullPath))
                    {
                        iTextSharp.text.Image img =
                            iTextSharp.text.Image.GetInstance(photoFullPath);

                        img.ScaleAbsolute(80f, 80f);
                        img.Alignment = Element.ALIGN_CENTER;
                        cell.AddElement(img);
                    }
                }

                cell.AddElement(new Paragraph("\n"));

                // Name
                Paragraph name = new Paragraph(
                    student.FirstName + " " + student.LastName,
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.WHITE));
                name.Alignment = Element.ALIGN_CENTER;
                cell.AddElement(name);

                // ID
                Paragraph idText = new Paragraph(
                    "ID: " + student.Id,
                    FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.WHITE));
                idText.Alignment = Element.ALIGN_CENTER;
                cell.AddElement(idText);

                table.AddCell(cell);
                doc.Add(table);

                doc.Close();

                return File(ms.ToArray(), "application/pdf", "FancyIDCard.pdf");
            }
        }

        // ================= HELPER METHOD =================
        private CollegeApplication GetStudentById(int id)
        {
            CollegeApplication student = null;

            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                string query = "SELECT * FROM CollegeApplications WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    student = new CollegeApplication
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        PhotoPath = reader["PhotoPath"].ToString(),
                        ApplicationPdfPath = reader["ApplicationPdfPath"].ToString()
                    };
                }
            }

            return student;
        }
    }
}