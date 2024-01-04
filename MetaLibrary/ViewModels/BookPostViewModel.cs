using System.ComponentModel.DataAnnotations;

namespace MetaLibrary.ViewModels
{
  public class BookPostViewModel
  {
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public DateTime Created { get; set; } = DateTime.Now;
  }
}
