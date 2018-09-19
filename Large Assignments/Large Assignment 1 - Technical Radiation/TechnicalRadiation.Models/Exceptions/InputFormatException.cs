using System;

namespace TechnicalRadiation.Models.Exceptions
{
    public class InputFormatException : Exception
    {
        public InputFormatException() : base("Model is not properly formatted.") {}
        public InputFormatException(string message) : base(message) {}
        public InputFormatException(string message, Exception inner) : base(message, inner) {} 
    }
}