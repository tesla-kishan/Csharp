using Microsoft.EntityFrameworkCore;
using OneToOneEFMVC.Data;
using OneToOneEFMVC.Services;

namespace OneToOneEFMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DbContext
            builder.Services.AddDbContext<StudentManagementContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add MVC
            builder.Services.AddControllersWithViews();

            // Register Service
            builder.Services.AddScoped<StudentService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}