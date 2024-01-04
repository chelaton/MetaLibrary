﻿using System.ComponentModel.DataAnnotations;

namespace MetaLibrary.ViewModels
{
  public class BookPutViewModel
  {

    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Author { get; set; }

  }
}
