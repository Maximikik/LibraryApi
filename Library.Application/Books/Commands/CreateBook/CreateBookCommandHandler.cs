using MediatR;
using Library.Domain;
using System.Runtime.CompilerServices;
using Library.Application.Interfaces;

namespace Library.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public CreateBookCommandHandler(ILibraryDbContext context) =>
        _libraryDbContext = context ?? throw new ArgumentNullException(nameof(context));
    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book()
        {
            Id = Guid.NewGuid(),
            ISBN = request.ISBN,
            Name = request.Name,
            Author = request.Author,
            Description = request.Description,
            Genre = request.Genre,
            RentStart = request.RentStart,
            RentEnd = request.RentEnd
        };

        await _libraryDbContext.Books.AddAsync(book, cancellationToken);
        await _libraryDbContext.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}
