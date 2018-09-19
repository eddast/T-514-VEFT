using System;
namespace TechnicalRadiation.Models.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base("Resource requested was not found.") {}
        public ResourceNotFoundException(string message) : base(message) {}
        public ResourceNotFoundException(string message, Exception inner) : base(message, inner) {}
    }
}