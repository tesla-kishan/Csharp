using Books.Models;

namespace Books.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        List<Book> GetBooksAbovePrice(int price);
        List<Book> GetBookByName(string name);
    }
}
