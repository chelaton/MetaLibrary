using System.ComponentModel.DataAnnotations;

namespace MetaLibrary.Data.Entities
{
  public class Book
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public DateTime Created { get; set; }= DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public DateTime? Deleted { get; set; }

  }
}
