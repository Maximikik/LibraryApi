namespace Library.Application.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
}
