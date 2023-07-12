using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    public readonly ILibraryDbContext _libraryDbContext;

    public DeleteUserCommandHandler(ILibraryDbContext libraryDbContext) =>
        _libraryDbContext = libraryDbContext;

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _libraryDbContext.Users.FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken)
            ?? throw new UserNotFoundException(request.Id.ToString());

        _libraryDbContext.Users.Remove(user);
        await _libraryDbContext.SaveChangesAsync(cancellationToken);
    }
}
