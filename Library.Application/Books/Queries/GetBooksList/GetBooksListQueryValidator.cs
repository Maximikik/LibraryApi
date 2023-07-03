using FluentValidation;

namespace Library.Application.Books.Queries.GetBooksList;

public class GetBooksListQueryValidator: AbstractValidator<GetBooksListQuery>
{
    public GetBooksListQueryValidator()
    { }
}
