using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        public DeleteBookCommandHandler(ILibraryDbContext context) =>
            _libraryDbContext = context ?? throw new ArgumentNullException(nameof(context));

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await _libraryDbContext.Books
                .FirstOrDefaultAsync(entity => entity.Id == request.Id && entity.ISBN == request.ISBN, cancellationToken);

            if (entity == null || entity.ISBN != request.ISBN || entity.Id != request.Id)
            {
                throw new NotFoundException(request.Id.ToString());
            }

            _libraryDbContext.Books.Remove(entity);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
