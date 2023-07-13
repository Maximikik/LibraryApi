using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.EditBookByISBN;

public class EditBookByISBNCommandHandler : IRequestHandler<EditBookByISBNCommand>
{
    private readonly ILibraryDbContext _libraryDbContext;
    public EditBookByISBNCommandHandler(ILibraryDbContext context)
        => _libraryDbContext = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Handle(EditBookByISBNCommand request, CancellationToken cancellationToken)
    {
        var entity = await _libraryDbContext.Books.
            FirstOrDefaultAsync(entity => entity.ISBN == request.ISBN, cancellationToken);

        if (entity == null || entity.ISBN != request.ISBN)
        {
            throw new NotFoundException($"Book with ISBN \"{request.ISBN}\" is not found!");
        }

        entity.ISBN = request.ISBN;
        entity.RentStart = request.RentStart;
        entity.RentEnd = request.RentEnd;
        entity.Author = request.Author;
        entity.Description = request.Description;
        entity.Name = request.Name;

        await _libraryDbContext.SaveChangesAsync(cancellationToken);
    }
}