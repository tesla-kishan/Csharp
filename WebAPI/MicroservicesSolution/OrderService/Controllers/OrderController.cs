using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.DTOs;
using OrderService.Models;
using OrderService.Messaging;
using System.Text.Json;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _context;
        private readonly RabbitMQPublisher _publisher;

        public OrderController(OrderDbContext context)
        {
            _context = context;
            _publisher = new RabbitMQPublisher();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            var order = new Order
            {
                ProductName = dto.ProductName,
                Amount = dto.Amount
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // 🔥 Publish Event
            var message = JsonSerializer.Serialize(order);
            _publisher.Publish(message);

            return Ok(order);
        }
    }
}