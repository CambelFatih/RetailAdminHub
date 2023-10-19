
namespace RetailAdminHub.Application.Exceptions;
/// <summary>
/// Represents an exception thrown when a product with a specific ID is not found.
/// </summary>
public class NotFoundProductException : Exception
{
    /// <summary>
    /// Initializes a new instance of the NotFoundProductException class with a default message.
    /// </summary>
    public NotFoundProductException() : base("There is no product matching this ID value. Please use another ID.")
    {
    }
}

