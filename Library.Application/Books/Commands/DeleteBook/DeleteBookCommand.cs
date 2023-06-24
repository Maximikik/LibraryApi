using MediatR;

namespace Library.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand: IRequest
{
    public Guid Id { get; set; }
    public string ISBN { get; set; } = null!;
}
