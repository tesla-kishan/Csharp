using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .AsNoTracking()
                .ToListAsync();
            return View(enrollments);
        }

        // GET: Enrollments/Create
        public async Task<IActionResult> Create()
        {
            ViewData["StudentId"] = new SelectList(await _context.Students.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewData["CourseId"] = new SelectList(await _context.Courses.AsNoTracking().ToListAsync(), "Id", "Title");
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId,EnrollmentDate")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.Enrollments.AnyAsync(e => e.StudentId == enrollment.StudentId && e.CourseId == enrollment.CourseId);
                if (exists)
                {
                    ModelState.AddModelError(string.Empty, "This student is already enrolled in the selected course.");
                }
                else
                {
                    _context.Add(enrollment);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Enrollment created successfully.";
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["StudentId"] = new SelectList(await _context.Students.AsNoTracking().ToListAsync(), "Id", "Name", enrollment.StudentId);
            ViewData["CourseId"] = new SelectList(await _context.Courses.AsNoTracking().ToListAsync(), "Id", "Title", enrollment.CourseId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null) return NotFound();

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Enrollment removed.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
