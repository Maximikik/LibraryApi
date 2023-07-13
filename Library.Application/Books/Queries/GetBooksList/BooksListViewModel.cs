using Library.Application.Common.Mapping;
using Library.Domain;

namespace Library.Application.Books.Queries.GetBooksList;

public class BooksListViewModel: IMapWith<Book>
{
    public IList<BookLookUpDataTransferObject>? Books { get; set; } 
}