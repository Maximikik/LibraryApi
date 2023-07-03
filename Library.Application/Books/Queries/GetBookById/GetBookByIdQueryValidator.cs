using FluentValidation;

namespace Library.Application.Books.Queries.GetBookById;

public class GetBookByIdQueryValidator: AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(getBookByIdQuery =>
            getBookByIdQuery.Id).NotEqual(Guid.Empty);
    }
}
