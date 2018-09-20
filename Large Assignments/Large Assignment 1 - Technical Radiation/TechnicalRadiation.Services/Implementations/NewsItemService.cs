using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    /// <summary>
    /// Gets news item data from repository and conducts paging
    /// </summary>
    public class NewsItemService : INewsItemService
    {
        /// <summary>
        /// News item repository
        /// </summary>
        private readonly INewsItemRepository _newsItemRepository;

        /// <summary>
        /// Initialize respository
        /// </summary>
        /// <param name="newsItemRepository">Which implementation of news item repository to use</param>
        public NewsItemService(INewsItemRepository newsItemRepository)
        {
            _newsItemRepository = newsItemRepository;
        }

        /// <summary>
        /// Returns list of all news items paged
        /// </summary>
        /// <param name="pageNumber">Which number of page to fetch news items of</param>
        /// <param name="pageSize">How many news items to display per page</param>
        /// <returns>list of all news items in descending order</returns>
        public IEnumerable<NewsItemDto> GetAllNewsItems(int PageSize, int PageNumber)
        {
            return PageService<NewsItemDto>.PageData(_newsItemRepository.GetAllNewsItems(), PageNumber, PageSize);
        }

        /// <summary>
        /// Gets news item from list with specified Id
        /// </summary>
        /// <param name="id">Id associated with news item to fetch</param>
        /// <returns>A single news item by id or throws exception if not found</returns>
        public NewsItemDetailDto GetNewsItemById(int id) 
        {
            var newsItem = _newsItemRepository.GetNewsItemById(id);
            if (newsItem == null) { throw new ResourceNotFoundException($"News item with id {id} was not found."); }
            return newsItem;
        }

    }
}