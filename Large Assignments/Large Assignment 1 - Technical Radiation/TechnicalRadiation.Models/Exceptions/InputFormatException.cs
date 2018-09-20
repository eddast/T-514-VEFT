using System;

namespace TechnicalRadiation.Models.Exceptions
{
    /// <summary>
    /// Exception thrown on 412 - precondition failed errors
    /// When user inputted model is not correctly formatted
    /// </summary>
    public class InputFormatException : Exception
    {
        /// <summary>
        /// Default message for exception thrown when model is badly-formatted
        /// </summary>
        /// <returns>Exception indicating model was badly-formatted</returns>
        public InputFormatException() : base("Model is not properly formatted.") {}

        /// <summary>
        /// Sets message for exception thrown when model is badly-formatted
        /// </summary>
        /// <returns>Exception indicating model was badly-formatted</returns>
        public InputFormatException(string message) : base(message) {}

        /// <summary>
        /// Sets message and exception thrown when model is badly-formatted
        /// </summary>
        /// <returns>Exception indicating model was badly-formatted</returns>
        public InputFormatException(string message, Exception inner) : base(message, inner) {} 
    }
}