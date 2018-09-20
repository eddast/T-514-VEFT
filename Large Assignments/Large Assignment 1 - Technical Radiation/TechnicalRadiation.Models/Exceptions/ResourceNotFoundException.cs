using System;
namespace TechnicalRadiation.Models.Exceptions
{
    /// <summary>
    /// Exception thrown on 404 - not found errors
    /// When resource requested was not found
    /// </summary>
    public class ResourceNotFoundException : Exception
    {
        /// <summary>
        /// Default message for exception thrown when resource requested is not found
        /// </summary>
        /// <returns>Exception indicating resource requested is not found</returns>
        public ResourceNotFoundException() : base("Resource requested was not found.") {}

        /// <summary>
        /// Sets message for exception thrown when resource requested is not found
        /// </summary>
        /// <returns>Exception indicating resource requested is not found</returns>
        public ResourceNotFoundException(string message) : base(message) {}

        /// <summary>
        /// Default message and exception thrown when resource requested is not found
        /// </summary>
        /// <returns>Exception indicating resource requested is not found</returns>
        public ResourceNotFoundException(string message, Exception inner) : base(message, inner) {}
    }
}