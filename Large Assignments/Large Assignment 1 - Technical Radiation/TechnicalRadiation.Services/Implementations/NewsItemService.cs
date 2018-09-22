using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Services.Implementations
{
    /// <summary>
    /// Gets news item data from repository and conducts paging and link relations for honoring HATEOAS
    /// </summary>
    public class NewsItemService : INewsItemService
    {
        /// <summary>
        /// News item repository
        /// </summary>
        private readonly INewsItemRepository _newsItemRepository;

        /// <summary>
        /// News item to category relations repository
        /// </summary>
        private readonly INewsItemCategoryRelationRepository _categoryRelationRepository;

        /// <summary>
        /// News item to authors relations repository
        /// </summary>
        private readonly IAuthorNewsItemRelationRepository _authorRelationRepository;

        /// <summary>
        /// Initialize respository
        /// </summary>
        /// <param name="newsItemRepository">Which implementation of news item repository to use</param>
        public NewsItemService(INewsItemRepository newsItemRepository, INewsItemCategoryRelationRepository categoryRelationRepository, IAuthorNewsItemRelationRepository authorRelationRepository)
        {
            _newsItemRepository = newsItemRepository;
            _categoryRelationRepository = categoryRelationRepository;
            _authorRelationRepository = authorRelationRepository;
        }

        /// <summary>
        /// Returns list of all news items paged within envelope with appropriate link relations
        /// </summary>
        /// <param name="pageNumber">Which number of page to fetch news items of</param>
        /// <param name="pageSize">How many news items to display per page</param>
        /// <returns>list of all news items in descending order encapsulated in envelope for paging info</returns>
        public Envelope<NewsItemDto> GetAllNewsItems(int PageNumber, int PageSize)
        {
            var allNewsItems = _newsItemRepository.GetAllNewsItems();
            IEnumerable<NewsItemDto> pagedNewsItems = PageService<NewsItemDto>.PageData(allNewsItems, PageNumber, PageSize);
            foreach (var n in pagedNewsItems) n.AddReferences(n.Id, getCategories(n.Id), getAuthors(n.Id));
            return new Envelope<NewsItemDto>
            {
                Items = PageService<NewsItemDto>.PageData(allNewsItems, PageNumber, PageSize),
                PageNumber = PageNumber,
                PageSize = PageSize,
                MaxPages = PageService<NewsItemDto>.GetMaxPages(allNewsItems.Count(), PageSize)
            };
        }

        /// <summary>
        /// Gets news item from list with specified id with appropriate link relations
        /// </summary>
        /// <param name="id">Id associated with news item to fetch</param>
        /// <returns>A single news item by id or throws exception if not found</returns>
        public NewsItemDetailDto GetNewsItemById(int id) 
        {
            var newsItem = _newsItemRepository.GetNewsItemById(id);
            if (newsItem == null) { throw new ResourceNotFoundException($"News item with id {id} was not found."); }
            newsItem.AddReferences(newsItem.Id, getCategories(newsItem.Id), getAuthors(newsItem.Id));
            return newsItem;
        }

        /// <summary>
        /// Gets all relations of news items to categories by id
        /// </summary>
        /// <param name="Id">id of news item to get category for</param>
        /// <returns>all relations of news items to categories by id</returns>
        private IEnumerable<NewsItemCategoryRelation> getCategories(int Id) =>
            _categoryRelationRepository.GetAllNewsItemsCategoryRelationsByNewsItemId(Id);

        /// <summary>
        /// Gets all relations of news items to authors by id
        /// </summary>
        /// <param name="Id">id of news item to get authors for</param>
        /// <returns>all relations of specific news item to authors by id</returns>
        private IEnumerable<AuthorNewsItemRelation> getAuthors(int newsItemId) =>
            _authorRelationRepository.GetAuthorsForNewsItems(newsItemId);
    }
}