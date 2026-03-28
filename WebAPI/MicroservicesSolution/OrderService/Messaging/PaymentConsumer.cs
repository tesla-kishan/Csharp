using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using OrderService.Data;

namespace OrderService.Messaging
{
    public class PaymentConsumer : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public PaymentConsumer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("paymentQueue", false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var data = JsonSerializer.Deserialize<PaymentResult>(message);

                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<OrderDbContext>();

                var order = await db.Orders.FindAsync(data.OrderId);

                if (order != null)
                {
                    order.Status = data.Status;
                    await db.SaveChangesAsync();
                }
            };

            channel.BasicConsume("paymentQueue", true, consumer);

            return Task.CompletedTask;
        }
    }

    public class PaymentResult
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
    }
}