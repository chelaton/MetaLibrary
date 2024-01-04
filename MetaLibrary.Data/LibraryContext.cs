using MetaLibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetaLibrary.Data;

public class LibraryContext : DbContext
{
  public LibraryContext(DbContextOptions<LibraryContext> options)  : base(options)
  {
  }

  public DbSet<Book> Books { get; set; } = null!;
}
