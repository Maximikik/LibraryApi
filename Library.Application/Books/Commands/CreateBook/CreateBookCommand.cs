using MediatR;

namespace Library.Application.Books.Commands.CreateBook;

public class CreateBookCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string ISBN { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Author { get; set; } = null!;
    public DateTime RentStart { get; set; }
    public DateTime RentEnd { get; set; }
}