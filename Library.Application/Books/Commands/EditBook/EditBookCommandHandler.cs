using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.EditBook;

public class EditBookCommandHandler : IRequestHandler<EditBookCommand>
{
    private readonly ILibraryDbContext _libraryDbContext;
    public EditBookCommandHandler(ILibraryDbContext context)
        => _libraryDbContext = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Handle(EditBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _libraryDbContext.Books.
            FirstOrDefaultAsync( entity => entity.Id == request.Id, cancellationToken );

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(request.Id.ToString());
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