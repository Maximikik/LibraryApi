using FluentValidation;

namespace Library.Application.Books.Commands.DeleteBookById;

public class DeleteBookByIdCommandValidator: AbstractValidator<DeleteBookByIdCommand>
{
    public DeleteBookByIdCommandValidator()
    {
        RuleFor(deleteBookByIdCommand =>
            deleteBookByIdCommand.Id).NotEqual(Guid.Empty);
    }
}
