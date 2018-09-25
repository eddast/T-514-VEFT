using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    /// <summary>
    /// Gets news item data from repository and conducts paging
    /// </summary>
    public interface INewsItemService
    {
        /// <summary>
        /// Returns list of all news items paged within envelope
        /// </summary>
        /// <param name="pageNumber">Which number of page to fetch news items of</param>
        /// <param name="pageSize">How many news items to display per page</param>
        /// <returns>list of all news items in descending order encapsulated in envelope for paging info</returns>
        Envelope<NewsItemDto> GetAllNewsItems(int pageNumber, int pageSize);

        /// <summary>
        /// Gets news item from list with specified Id
        /// </summary>
        /// <param name="id">Id associated with news item to fetch</param>
        /// <returns>A single news item by id or throws exception if not found</returns>
        NewsItemDetailDto GetNewsItemById(int id);

        /// <summary>
        /// Creates new news item to system
        /// </summary>
        /// <param name="newsItem">new news item to add</param>
        /// <returns>the id of new news item</returns>
        int CreateNewsItem(NewsItemInputModel newsItem);

        /// <summary>
        /// Updates news item by id
        /// </summary>
        /// <param name="newsItem">new information on news item to switch to</param>
        /// <param name="id">id of news item to update</param>
        void UpdateNewsItemById(NewsItemInputModel newsItem, int id);

        /// <summary>
        /// Deletes news item by id
        /// </summary>
        /// <param name="id">id of news item to delete</param>
        void DeleteNewsItemById(int id);
    }
}