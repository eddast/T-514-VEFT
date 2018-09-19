using Newtonsoft.Json;

namespace TechnicalRadiation.Models.Exceptions
{
    /// <summary>
    /// API response format on exception
    /// </summary>
    public class ExceptionModel
    {
        /// <summary>
        /// HTTP status code associated with exception
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Informative message associated with exception
        /// </summary>
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}