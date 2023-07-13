using MediatR;

namespace Library.Application.Books.Queries.GetBookByISBN;

public class GetBookByISBNQuery: IRequest<BookViewModel>
{
    public string ISBN { get; set; } = null!;
}
