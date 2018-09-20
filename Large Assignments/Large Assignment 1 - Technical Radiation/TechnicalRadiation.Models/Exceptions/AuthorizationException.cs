using System;

namespace TechnicalRadiation.Models.Exceptions
{
    /// <summary>
    /// Exception thrown on 401 - unauthorized errors
    /// When user requestes resource that user hasn't got access to
    /// </summary>
    public class AuthorizationException : Exception
    {
        /// <summary>
        /// Default message for exception thrown when user requestes resource they haven't got access to
        /// </summary>
        /// <returns>Exception indicating user requested they haven't got access to</returns>
        public AuthorizationException() : base("Resource requested was not found.") {}

        /// <summary>
        /// Sets message for exception thrown when user requestes resource they haven't got access to
        /// </summary>
        /// <returns>Exception indicating  user requested they haven't got access to</returns>
        public AuthorizationException(string message) : base(message) {}

        /// <summary>
        /// Default message and exception thrown when resource requested is not found
        /// </summary>
        /// <returns>Exception indicating model resource requested is not found</returns>
        public AuthorizationException(string message, Exception inner) : base(message, inner) {}
    }
}