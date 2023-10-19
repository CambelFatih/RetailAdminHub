using System;

namespace RetailAdminHub.Application.Exceptions
{
    /// <summary>
    /// Represents a custom exception thrown when a product with a specific ID is not found.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the NotFoundException class with a custom message.
        /// </summary>
        /// <param name="message">The custom error message.</param>
        public NotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NotFoundException class with a default message.
        /// </summary>
        public NotFoundException() : base("Resource not found.")
        {
        }
    }
}
