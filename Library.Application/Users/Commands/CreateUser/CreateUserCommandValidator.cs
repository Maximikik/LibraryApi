using FluentValidation;

namespace Library.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.Password).MinimumLength(6).MaximumLength(20);
    }
}
