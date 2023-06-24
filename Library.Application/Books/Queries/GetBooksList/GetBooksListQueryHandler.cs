using MediatR;

namespace Library.Application.Books.Queries.GetBooksList;

public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, BookVm>
{
    public async Task<BookVm> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
    {
        
    }
}
