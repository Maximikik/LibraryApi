using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBookByISBN;

public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, BookVm>
{
    private readonly ILibraryDbContext _libraryDbContext;
    private readonly IMapper _mapper;

    public GetBookByISBNQueryHandler(ILibraryDbContext context, IMapper mapper) =>
        (_libraryDbContext, _mapper) = (context, mapper);

    public async Task<BookVm> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
    {
        var entity = await _libraryDbContext.Books.
            FirstOrDefaultAsync(entity => entity.ISBN == request.ISBN, cancellationToken);

        if (entity == null || entity.ISBN != request.ISBN)
        {
            throw new NotFoundException();
        }

        return _mapper.Map<BookVm>(entity);
    }
}
