using FluentValidation;

namespace Library.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(createBookCommand =>
            createBookCommand.Id).NotEqual(Guid.Empty);
        RuleFor(createBookCommand =>
            createBookCommand.Author).NotEmpty().MaximumLength(250);
        RuleFor(createBookCommand =>
            createBookCommand.Name).NotEmpty().MaximumLength(250);
        RuleFor(createBookCommand =>
            createBookCommand.ISBN).Length(13);
        RuleFor(createBookCommand =>
            createBookCommand.Description).NotEmpty().MaximumLength(250);
        RuleFor(createBookCommand =>
            createBookCommand.Genre).NotEmpty().MaximumLength(250);
        RuleFor(createBookCommand =>
            createBookCommand.RentStart).LessThanOrEqualTo(DateTime.Now);
        RuleFor(createBookCommand =>
            createBookCommand.RentEnd)
            .GreaterThanOrEqualTo(createBookCommand => createBookCommand.RentStart);
    }
}
