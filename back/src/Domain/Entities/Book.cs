using FluentValidation;

namespace Domain.Entities;

public class Book : Entity<Book>
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Description { get; private set; }

    public Book(string title, string author, string description)
    {
        Title = title;
        Author = author;
        Description = description;
        CreatedDate = DateTime.Now; // Define CreatedDate diretamente
        ValidateEntity(); // Valida o objeto ao ser criado
    }
    
    private void ValidateEntity()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(255).WithMessage("Title must be less than 255 characters.");

        RuleFor(b => b.Author)
            .NotEmpty().WithMessage("Author is required.")
            .MaximumLength(255).WithMessage("Author must be less than 255 characters.");

        RuleFor(b => b.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(1000).WithMessage("Description must be less than 1000 characters.");

        ValidationResult = Validate(this);
    }

    public override bool IsValid()
    {
        return ValidationResult.IsValid;
    }
}
