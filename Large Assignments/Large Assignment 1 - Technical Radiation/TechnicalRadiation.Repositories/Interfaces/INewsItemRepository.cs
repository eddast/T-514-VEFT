using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.InputModels;

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

        /// <summary>
        /// Creates new news item and adds to data
        /// </summary>
        /// <param name="newsItem">news item to add to data</param>
        /// <returns>the id of the new news item</returns>
        int CreateNewsItem(NewsItemInputModel newsItem);

        /// <summary>
        /// Updates news item by id
        /// </summary>
        /// <param name="newsItem">new news item values to set to old news item</param>
        /// <param name="id">id of news item to update</param>
        void UpdateNewsItemById(NewsItemInputModel newsItem, int id);

        /// <summary>
        /// Deletes news item from system
        /// </summary>
        /// <param name="id">the id of news item to delete from system</param>
        void DeleteNewsItem(int id);
    }
}