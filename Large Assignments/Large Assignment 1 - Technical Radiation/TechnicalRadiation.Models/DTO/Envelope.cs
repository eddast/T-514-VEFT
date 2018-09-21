using System.Collections.Generic;

namespace TechnicalRadiation.Models.DTO
{
    /// <summary>
    /// Envelope for HTTP responses with paged data
    /// </summary>
    public class Envelope<T> where T : class
    {
        /// <summary>
        /// Paged list of items
        /// </summary>
        public IEnumerable<T> Items { get; set; }
        /// <summary>
        /// Number of items per page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Index as to which page was fetched
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Maximum number of pages of items for a given page size
        /// </summary>
        public int MaxPages { get; set; }
    }
}