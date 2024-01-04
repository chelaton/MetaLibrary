using MetaLibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetaLibrary.Data.Repository
{
  public class BookRepository : IBookRepository
  {
    private readonly LibraryContext libraryContext;

    public BookRepository(LibraryContext libraryContext)
    {
      this.libraryContext = libraryContext;
    }
    public IQueryable<Book> GetBooks()
    {
      return libraryContext.Books.AsQueryable();
    }

    public async Task<int?> CreateBook(Book book)
    {
      var data = await libraryContext.Books.AddAsync(book);
      if (data.State == EntityState.Added) 
      {
        libraryContext.SaveChanges();
        return data.Entity.Id;
      }
      else
      {
        return null;
      }
    }
    
    public async Task SaveChanges()
    {
      await libraryContext.SaveChangesAsync();
    }
  }
}
