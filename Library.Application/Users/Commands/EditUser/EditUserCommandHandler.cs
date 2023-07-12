using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Users.Commands.EditUser;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
{
    public readonly ILibraryDbContext _libraryDbContext;

    public EditUserCommandHandler(ILibraryDbContext libraryDbContext) =>
        _libraryDbContext = libraryDbContext;
    public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _libraryDbContext.Users.FirstOrDefaultAsync(entity => entity.Id == request.Id)
            ?? throw new UserNotFoundException(request.Id.ToString());

        user.Email = request.Email;
        user.Password = request.Password;

        await _libraryDbContext.SaveChangesAsync(cancellationToken);
    }
}