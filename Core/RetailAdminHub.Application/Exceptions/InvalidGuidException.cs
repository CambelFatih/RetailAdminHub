
namespace RetailAdminHub.Application.Exceptions;

public class InvalidGuidException : Exception
{
    public InvalidGuidException() : base("No valid Guid value was provided. Please enter a value of type Guid.")
    {
    }

    public InvalidGuidException(string message) : base(message)
    {
    }

    public InvalidGuidException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

