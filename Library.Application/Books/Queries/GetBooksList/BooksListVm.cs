using Library.Application.Common.Mapping;
using Library.Domain;

namespace Library.Application.Books.Queries.GetBooksList;

public class BooksListVm: IMapWith<Book>
{
    public IList<BookLookUpDto>? Books { get; set; } 
}