using System.ComponentModel.DataAnnotations;

namespace MetaLibrary.Core.Models
{
  public class BookDto
  {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public DateTime? Deleted { get; set; }
  }
}
