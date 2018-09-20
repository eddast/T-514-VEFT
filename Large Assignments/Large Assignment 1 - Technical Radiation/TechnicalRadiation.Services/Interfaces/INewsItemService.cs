using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Services.Interfaces
{
    /// <summary>
    /// Gets news item data from repository and conducts paging
    /// </summary>
    public interface INewsItemService
    {
        /// <summary>
        /// Returns list of all news items paged
        /// </summary>
        /// <param name="pageNumber">Which number of page to fetch news items of</param>
        /// <param name="pageSize">How many news items to display per page</param>
        /// <returns>list of all news items in descending order</returns>
        IEnumerable<NewsItemDto> GetAllNewsItems(int pageNumber, int pageSize);

        /// <summary>
        /// Gets news item from list with specified Id
        /// </summary>
        /// <param name="id">Id associated with news item to fetch</param>
        /// <returns>A single news item by id or throws exception if not found</returns>
        NewsItemDetailDto GetNewsItemById(int id);
    }
}