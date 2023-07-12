using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public CreateUserCommandHandler(ILibraryDbContext libraryDbContext) =>
        _libraryDbContext = libraryDbContext;


    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Password = request.Password
        };

        await _libraryDbContext.Users.AddAsync(user);
        await _libraryDbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}