using FluentValidation;

namespace Library.Application.Books.Queries.GetBookByISBN;

public class GetBookByISBNQueryValidator: AbstractValidator<GetBookByISBNQuery>
{
    public GetBookByISBNQueryValidator()
    {
        RuleFor(getBookByISBNQuery => 
            getBookByISBNQuery.ISBN).Length(13); 
    }
}
