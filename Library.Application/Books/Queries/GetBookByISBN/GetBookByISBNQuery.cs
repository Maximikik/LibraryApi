using MediatR;

namespace Library.Application.Books.Queries.GetBookByISBN;

public class GetBookByISBNQuery: IRequest<BookVm>
{
    public string ISBN { get; set; } = null!;
}
