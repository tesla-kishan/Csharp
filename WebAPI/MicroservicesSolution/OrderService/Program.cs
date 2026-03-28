using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Messaging; // ✅ IMPORTANT (for PaymentConsumer)

namespace OrderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ DB
            builder.Services.AddDbContext<OrderDbContext>(options =>
                options.UseSqlServer("Server=KishanPc\\SQLEXPRESS;Database=OrderDB;Trusted_Connection=True;TrustServerCertificate=True;"));

            // ✅ Controllers
            builder.Services.AddControllers();

            // ✅ Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 🔥 ADD THIS LINE HERE (IMPORTANT)
            builder.Services.AddHostedService<PaymentConsumer>();

            var app = builder.Build();

            // ✅ Swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}