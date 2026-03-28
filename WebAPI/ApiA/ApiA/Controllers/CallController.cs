using Microsoft.AspNetCore.Mvc;

namespace ApiA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CallController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<string> Get(int number)
        {
            var squareUrl = $"https://localhost:7034/Math/square?number={number}";
            var cubeUrl = $"https://localhost:7034/Math/cube?number={number}";

            var square = await _httpClient.GetStringAsync(squareUrl);
            var cube = await _httpClient.GetStringAsync(cubeUrl);

            return $"Square: {square}, Cube: {cube}";
        }
    }
}