using FluentValidation;

namespace Library.Application.Books.Commands.DeleteBookByISBN;

public class DeleteBookByISBNCommandValidator: AbstractValidator<DeleteBookByISBNCommand>
{
    public DeleteBookByISBNCommandValidator()
    {
        RuleFor(deleteBookByISBNCommand =>
            deleteBookByISBNCommand.ISBN).Length(13);
    }
}
