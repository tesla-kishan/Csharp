using Books.Models;
using Books.Data;

namespace Books.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public List<Book> GetBooksAbovePrice(int price)
        {
            return _context.Books.Where(b => b.Price > price).ToList();
        }

        public List<Book> GetBookByName(string name)
        {
            return _context.Books.Where(b => b.FullName == name).ToList();
        }
    }
}