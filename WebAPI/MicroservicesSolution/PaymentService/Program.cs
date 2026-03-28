using Microsoft.EntityFrameworkCore;
using PaymentService.Data;
using PaymentService.Messaging;

namespace PaymentService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PaymentDbContext>(options =>
                options.UseSqlServer("Server=KishanPc\\SQLEXPRESS;Database=PaymentDB;Trusted_Connection=True;TrustServerCertificate=True;"));

            builder.Services.AddHostedService<RabbitMQConsumer>();

            builder.Services.AddControllers();

            // ✅ Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ✅ Enable Swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}