using MediatR;

namespace Library.Application.Books.Commands.DeleteBookByISBN;

public class DeleteBookByISBNCommand : IRequest
{
    public string ISBN { get; set; } = null!;
}
