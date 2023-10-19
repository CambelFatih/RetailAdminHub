
namespace RetailAdminHub.Application.Exceptions;
/// <summary>
/// Represents an exception thrown when an invalid Guid value is provided.
/// </summary>
public class InvalidGuidException : Exception
{
    /// <summary>
    /// Initializes a new instance of the InvalidGuidException class with a default message.
    /// </summary>
    public InvalidGuidException() : base("No valid Guid value was provided. Please enter a value of type Guid.")
    {
    }
    /// <summary>
    /// Initializes a new instance of the InvalidGuidException class with a custom message.
    /// </summary>
    /// <param name="message">The custom error message.</param>
    public InvalidGuidException(string message) : base(message)
    {
    }
    /// <summary>
    /// Initializes a new instance of the InvalidGuidException class with a custom message and an inner exception.
    /// </summary>
    /// <param name="message">The custom error message.</param>
    /// <param name="innerException">The inner exception that caused this exception.</param>
    public InvalidGuidException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

