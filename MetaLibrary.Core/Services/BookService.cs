using AutoMapper;
using MetaLibrary.Core.Models;
using MetaLibrary.Data.Entities;
using MetaLibrary.Data.Repository;
using Microsoft.EntityFrameworkCore;


namespace MetaLibrary.Core.Services;

public class BookService : IBookService
{
  private readonly IBookRepository bookRepository;
  private readonly IMapper mapper;

  public BookService(IBookRepository bookRepository, IMapper mapper)
  {
    this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  public async Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken)
  {
    var books = await bookRepository.GetBooks().Where(x => x.Deleted == null).ToListAsync(cancellationToken);
    return books;
  }

  public async Task<int?> CreateBook(BookDto bookDto)
  {
    try
    {
      var book = mapper.Map<Book>(bookDto);
      var id = await bookRepository.CreateBook(book);

      if (id != null)
      {
        return id;
      }
      else
      {
        return null;
      }
    }
    catch (Exception ex)
    {
      // Handle unexpected exceptions
      throw new Exception(ex.ToString());
    }

  }

  public async Task<Book> GetBookByIdAsync(int id)
  {
    var book = await bookRepository.GetBooks().FirstOrDefaultAsync(b => b.Id == id);
    if (book != null)
    {
      return book;
    }
    return null;
  }

  public async Task<Book> UpdateBook(BookDto bookDto)
  {
    try
    {
      var book = await bookRepository.GetBooks().FirstOrDefaultAsync(b => b.Id == bookDto.Id);
      if (book != null) 
      {
        book = mapper.Map(bookDto, book);
        book.Updated = DateTime.UtcNow;
        await bookRepository.SaveChanges();
        return book;
      }
      return null;
    }
    catch (Exception ex)
    {
      // Handle unexpected exceptions
      throw new Exception(ex.ToString());
    }
  }

  public async Task DeleteBook(int bookId)
  {
    try
    {
      var book = await bookRepository.GetBooks().FirstOrDefaultAsync(b => b.Id == bookId);
      book.Deleted = DateTime.UtcNow;
      await bookRepository.SaveChanges();
    }
    catch (Exception ex)
    {
      // Handle unexpected exceptions
      throw new Exception(ex.ToString());
    }
  }
}
