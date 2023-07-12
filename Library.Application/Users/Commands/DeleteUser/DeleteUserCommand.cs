using MediatR;

namespace Library.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand: IRequest
{
    public Guid Id { get; set; }
}
