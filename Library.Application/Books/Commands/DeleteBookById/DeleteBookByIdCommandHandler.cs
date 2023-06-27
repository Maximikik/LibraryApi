using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.DeleteBookById
{
    public class DeleteBookByIdCommandHandler : IRequestHandler<DeleteBookByIdCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        public DeleteBookByIdCommandHandler(ILibraryDbContext context) =>
            _libraryDbContext = context ?? throw new ArgumentNullException(nameof(context));

        public async Task Handle(DeleteBookByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _libraryDbContext.Books
                .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(request.Id.ToString());
            }

            _libraryDbContext.Books.Remove(entity);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
