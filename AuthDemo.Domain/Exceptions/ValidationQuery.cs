namespace AuthDemo.Domain.Exceptions;

public class ValidationQuery : Exception
{
    public ValidationQuery(string? message) : base(message)
    {
    }
}
