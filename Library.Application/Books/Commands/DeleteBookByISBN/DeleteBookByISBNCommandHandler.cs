using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.DeleteBookByISBN;

public class DeleteBookByISBNCommandHandler : IRequestHandler<DeleteBookByISBNCommand>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public DeleteBookByISBNCommandHandler(ILibraryDbContext context) =>
        _libraryDbContext = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Handle(DeleteBookByISBNCommand request, CancellationToken cancellationToken)
    {
        var entity = await _libraryDbContext.Books
            .FirstOrDefaultAsync(entity => entity.ISBN == request.ISBN, cancellationToken);

        if (entity == null || entity.ISBN != request.ISBN)
        {
            throw new NotFoundException();
        }

        _libraryDbContext.Books.Remove(entity);
        await _libraryDbContext.SaveChangesAsync(cancellationToken);
    }
}
