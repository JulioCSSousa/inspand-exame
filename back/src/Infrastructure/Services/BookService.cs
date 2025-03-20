using Domain.Entities;
using Domain.Interfaces;
using FluentValidation.Results;

namespace Infrastructure.Services;

public class BookService : IBookService
{
    private readonly IRepository<Book> _bookRepository;

    public BookService(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    }

    public async Task<ValidationResult> InsertAsync(Book book)
    {
        if (book == null)
            return new ValidationResult { Errors = { new ValidationFailure("Book", "Book cannot be null") } };

        if (!book.IsValid()) return book.ValidationResult;

        await _bookRepository.InsertAsync(book);
        return new ValidationResult();
    }

    public async Task<ValidationResult> DeleteAsync(long id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
            return new ValidationResult { Errors = { new ValidationFailure("Id", "Book not found") } };

        await _bookRepository.DeleteAsync(id);
        return new ValidationResult();
    }

    public async Task<ValidationResult> UpdateAsync(Book book)
    {
        var existingBook = await _bookRepository.GetByIdAsync(book.Id);
        if (existingBook == null)
            return new ValidationResult { Errors = { new ValidationFailure("Id", "Book not found") } };

        // Atualiza os valores antes de validar
        existingBook = new Book(book.Title, book.Author, book.Description);

        if (!existingBook.IsValid()) return existingBook.ValidationResult;

        await _bookRepository.UpdateAsync(existingBook);
        return new ValidationResult();
    }

    public async Task<Book> GetByIdAsync(long id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _bookRepository.GetAllAsync();
    }
    
}
