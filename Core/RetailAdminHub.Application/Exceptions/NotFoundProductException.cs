
namespace RetailAdminHub.Application.Exceptions;

public class NotFoundProductException : Exception
{
    public NotFoundProductException() : base("There is no product matching this ID value. Please use another ID.")
    {
    }
}

