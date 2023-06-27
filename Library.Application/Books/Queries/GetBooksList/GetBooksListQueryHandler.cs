using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBooksList;

public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, BooksListVm>
{
    private readonly ILibraryDbContext _libraryDbContext;
    private readonly IMapper _mapper;
    public GetBooksListQueryHandler(ILibraryDbContext context, IMapper mapper) =>
        (_libraryDbContext, _mapper) = (context, mapper);
    public async Task<BooksListVm> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
    {
        var booksList = await _libraryDbContext.Books
            .ProjectTo<BookLookUpDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new BooksListVm { Books = booksList };
    }
}
