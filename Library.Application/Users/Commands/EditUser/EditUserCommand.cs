using MediatR;

namespace Library.Application.Users.Commands.EditUser;

public class EditUserCommand: IRequest
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}