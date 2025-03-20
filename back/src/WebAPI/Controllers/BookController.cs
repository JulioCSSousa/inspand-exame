using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using WebApi.Dtos;
using FluentValidation.Results;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> Get()
    {
        var books = await _bookService.GetAllAsync();

        var bookDtos = books.Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description
        });

        return Ok(bookDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetById(long id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book == null) return NotFound();

        var bookDto = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description
        };

        return Ok(bookDto);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createDto)
    {
        var book = new Book(createDto.Title, createDto.Author, createDto.Description);

        var validationResult = await _bookService.InsertAsync(book);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var createdBook = await _bookService.GetByIdAsync(book.Id);

        var bookDto = new BookDto
        {
            Id = createdBook.Id,
            Title = createdBook.Title,
            Author = createdBook.Author,
            Description = createdBook.Description
        };

        return CreatedAtAction(nameof(GetById), new { id = bookDto.Id }, bookDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(long id, [FromBody] UpdateBookDto updateDto)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book == null) return NotFound();

        book = new Book(updateDto.Title, updateDto.Author, updateDto.Description);

        var validationResult = await _bookService.UpdateAsync(book);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book == null) return NotFound();

        await _bookService.DeleteAsync(id);
        return NoContent();
    }
}
