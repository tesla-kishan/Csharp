using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Models;
using System.Net.Http.Json;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly HttpClient _httpClient;

        public OrdersController(UserDbContext context, IHttpClientFactory factory)
        {
            _context = context;
            _httpClient = factory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}