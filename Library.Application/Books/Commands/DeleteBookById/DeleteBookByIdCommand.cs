using MediatR;

namespace Library.Application.Books.Commands.DeleteBookById;

public class DeleteBookByIdCommand: IRequest
{
    public Guid Id { get; set; }
}
