using Books.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("allbooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(_repository.GetAllBooks());
        }

        [HttpGet("GetBooksAbovePrice")]
        public IActionResult GetBooksAbovePrice(int price)
        {
            return Ok(_repository.GetBooksAbovePrice(price));
        }

        [HttpGet("GetBookByName")]
        public IActionResult GetBookByName(string name)
        {
            return Ok(_repository.GetBookByName(name));
        }
    }
}