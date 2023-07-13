using FluentValidation;

namespace Library.Application.Books.Commands.EditBookByISBN;

public class EditBookByISBNCommandValidator : AbstractValidator<EditBookByISBNCommand>
{
    public EditBookByISBNCommandValidator()
    {
        RuleFor(editBookCommand =>
            editBookCommand.Author).NotEmpty().MaximumLength(250);
        RuleFor(editBookCommand =>
            editBookCommand.Name).NotEmpty().MaximumLength(250);
        RuleFor(editBookCommand =>
            editBookCommand.ISBN).Length(13);
        RuleFor(editBookCommand =>
            editBookCommand.Description).NotEmpty().MaximumLength(250);
        RuleFor(editBookCommand =>
            editBookCommand.Genre).NotEmpty().MaximumLength(250);
        RuleFor(editBookCommand =>
            editBookCommand.RentStart).LessThanOrEqualTo(DateTime.Now);
        RuleFor(editBookCommand =>
            editBookCommand.RentEnd)
            .GreaterThanOrEqualTo(editBookCommand => editBookCommand.RentStart);
    }
}