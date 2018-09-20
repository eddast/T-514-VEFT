using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Repositories.Interfaces
{
    /// <summary>
    /// Gets news item data from data provider
    /// </summary>
    public interface INewsItemRepository
    {
        /// <summary>
        /// Returns list of all news items in descending order
        /// </summary>
        /// <returns>list of all news items in descending order</returns>
        IEnumerable<NewsItemDto> GetAllNewsItems();

        /// <summary>
        /// Gets a single news item by id
        /// </summary>
        /// <param name="id">id of news item to get</param>
        /// <typeparam name="NewsItemDetailDto">Single news item detail information</typeparam>
        /// <returns>Single news item detail information by id or throws not found error</returns>
        NewsItemDetailDto GetNewsItemById(int id);
        
    }
}