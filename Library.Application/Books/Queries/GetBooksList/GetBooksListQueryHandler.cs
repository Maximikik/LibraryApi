using MediatR;

namespace Library.Application.Books.Queries.GetBooksList;

public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, BooksListVm>
{
    public async Task<BooksListVm> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
    {
        
    }
}
