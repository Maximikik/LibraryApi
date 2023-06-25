using MediatR;

namespace Library.Application.Books.Queries.GetBooksList;

public class GetBooksListQuery:  IRequest<BooksListVm>
{
    public Guid Id { get; set; }
}
