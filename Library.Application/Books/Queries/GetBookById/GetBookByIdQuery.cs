using MediatR;

namespace Library.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery: IRequest<BookVm>
    {
        public Guid Id { get; set; }

    }
}
