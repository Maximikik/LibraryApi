namespace Library.Application.Common.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(string id): base($"Book with Id: \"{id}\" is not found!") { }
    public NotFoundException(): base("Book is not found!") { }
}
