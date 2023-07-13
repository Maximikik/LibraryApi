using AutoMapper;
using Library.Application.Books.Queries.GetBookByISBN;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookViewModel>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(ILibraryDbContext context, IMapper mapper) =>
            (_libraryDbContext, _mapper) = (context, mapper);

        public async Task<BookViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _libraryDbContext.Books
                .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(request.Id.ToString());
            }

            return _mapper.Map<BookViewModel>(entity);
        }
    }
}
