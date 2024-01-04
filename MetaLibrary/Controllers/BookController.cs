using AutoMapper;
using MetaLibrary.Core.Models;
using MetaLibrary.Core.Services;
using MetaLibrary.Data.Entities;
using MetaLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MetaLibrary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BookController : ControllerBase
  {
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookController(IBookService bookService, IMapper mapper)
    {
      _bookService = bookService;
      _mapper = mapper;
    }

    // GET: api/<ValuesController>
    [SwaggerOperation("Get all books.")]
    [HttpGet]
    public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    {
      var result = await _bookService.GetBooksAsync(cancellationToken);
      if (result.Count>0)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    // GET api/<ValuesController>/5
    [SwaggerOperation("Get book by Id.")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var result = await _bookService.GetBookByIdAsync(id);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // POST api/<ValuesController>
    [SwaggerOperation("Create book.")]
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] BookPostViewModel book)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Invalid model object");
      }
      var bookDto = _mapper.Map<BookDto>(book);
      var result = await _bookService.CreateBook(bookDto);


      if (result!=null)
      {
        return Ok(result);
      }
      else
      {
        return BadRequest("Something wrong happened");
      }
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    [SwaggerOperation("Update book.")]
    public async Task<ActionResult<Book>> Put(int id, [FromBody] BookPutViewModel bookPutViewModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Invalid model object");
      }
      if (id!=bookPutViewModel.Id)
      {
        return BadRequest("Invalid model object");
      }

      var bookDto = _mapper.Map<BookDto>(bookPutViewModel);
      var result = await _bookService.UpdateBook(bookDto);


      if (result != null)
      {
        return Ok(result);
      }
      else
      {
        return BadRequest("Something wrong happened");
      }
    }

    // DELETE api/<ValuesController>/5
    [SwaggerOperation("Delete book.")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _bookService.DeleteBook(id);
      return Ok();
    }
  }
}
