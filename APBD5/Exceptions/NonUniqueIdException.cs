namespace APBD5.Exceptions;

public class NonUniqueIdException : Exception
{
    public NonUniqueIdException(string? message) : base(message)
    {
        
    }

    public NonUniqueIdException()
    {
    }
}