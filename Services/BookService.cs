using Microsoft.EntityFrameworkCore;
using SimpleLibraryAPI.Context;
using SimpleLibraryAPI.Models;
using SimpleLibraryAPI.Interfaces;

namespace SimpleLibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly MyDbContext _context;
        public BookService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddBook(Book inputBook)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Title == inputBook.Title);
            if (book != null) 
            {
                return null;
            }
            await _context.Books.AddAsync(inputBook);
            await _context.SaveChangesAsync();
            return inputBook;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetBookById(int id)
        {
            Book chosenBook = await _context.Books.FirstOrDefaultAsync(foundBook => foundBook.Id == id);
            return chosenBook;
        }
        public async Task<Book> UpdateBook(Book book, int id)
        {
            var foundBook = await GetBookById(id);
            if (foundBook is null)
            {
                return null;
            }
            foundBook.Title = book.Title;
            foundBook.Author = book.Author;
            foundBook.PublicationYear = book.PublicationYear;
            foundBook.ISBN = book.ISBN;
            await _context.SaveChangesAsync();
            return foundBook;
        }
        public async Task<bool> DeleteBook(int id)
        {
            var foundBook = await GetBookById(id);
            if (foundBook is null)
            {
                return false;
            }
            _context.Books.Remove(foundBook);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
