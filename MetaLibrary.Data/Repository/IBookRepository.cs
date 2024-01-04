using MetaLibrary.Data.Entities;

namespace MetaLibrary.Data.Repository
{
  public interface IBookRepository
  {
    Task<int?> CreateBook(Book book);
    IQueryable<Book> GetBooks();
    Task SaveChanges();
  }
}