using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using PaymentService.Data;
using PaymentService.Models;

namespace PaymentService.Messaging
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RabbitMQConsumer(IServiceScopeFactory scopeFactory)
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

            // 🔹 Listen to Order Queue
            channel.QueueDeclare(
                queue: "orderQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var order = JsonSerializer.Deserialize<OrderMessage>(message);

                    using var scope = _scopeFactory.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<PaymentDbContext>();

                    // 🔥 PAYMENT LOGIC
                    var payment = new Payment
                    {
                        OrderId = order.Id,
                        Status = "Success"
                    };

                    db.Payments.Add(payment);
                    await db.SaveChangesAsync();

                    Console.WriteLine($"✅ Payment processed for Order {order.Id}");

                    // 🔥 SAGA: Send result back to OrderService
                    var factory2 = new ConnectionFactory() { HostName = "localhost" };
                    using var conn2 = factory2.CreateConnection();
                    using var channel2 = conn2.CreateModel();

                    channel2.QueueDeclare(
                        queue: "paymentQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var resultMessage = JsonSerializer.Serialize(new
                    {
                        OrderId = order.Id,
                        Status = "Success"
                    });

                    var body2 = Encoding.UTF8.GetBytes(resultMessage);

                    channel2.BasicPublish(
                        exchange: "",
                        routingKey: "paymentQueue",
                        basicProperties: null,
                        body: body2
                    );

                    Console.WriteLine($"📤 Payment result sent for Order {order.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }
            };

            channel.BasicConsume(
                queue: "orderQueue",
                autoAck: true,
                consumer: consumer
            );

            return Task.CompletedTask;
        }
    }

    // DTO for incoming message
    public class OrderMessage
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
    }
}