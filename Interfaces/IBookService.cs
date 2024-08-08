using SimpleLibraryAPI.Models;

namespace SimpleLibraryAPI.Interfaces
{
    public interface IBookService
    {
        Task<Book> AddBook(Book book);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> UpdateBook(Book book, int id);
        Task<bool> DeleteBook(int id);
    }
}
