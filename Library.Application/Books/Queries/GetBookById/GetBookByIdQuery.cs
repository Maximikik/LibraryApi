using Library.Application.Books.Queries.GetBookByISBN;
using MediatR;

namespace Library.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery: IRequest<BookViewModel>
    {
        public Guid Id { get; set; }
    }
}
