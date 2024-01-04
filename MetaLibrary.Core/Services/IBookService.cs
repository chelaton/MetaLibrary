using MetaLibrary.Core.Models;
using MetaLibrary.Data.Entities;

namespace MetaLibrary.Core.Services
{
    public interface IBookService
    {
    Task<int?> CreateBook(BookDto bookDto);
    Task<Book> UpdateBook(BookDto bookDto);
    Task<Book> GetBookByIdAsync(int id);
    Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken);
    Task DeleteBook(int bookId);
  }
}