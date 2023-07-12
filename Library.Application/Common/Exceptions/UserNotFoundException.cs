namespace Library.Application.Common.Exceptions;

public class UserNotFoundException: Exception
{
    public UserNotFoundException(string id) : base($"User with Id: \"{id}\" is not found!") { }
    public UserNotFoundException() : base("User is not found!") { }
}
