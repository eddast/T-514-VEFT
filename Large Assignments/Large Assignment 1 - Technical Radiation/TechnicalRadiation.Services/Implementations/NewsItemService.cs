using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    public class NewsItemService : INewsItemService
    {
        private readonly INewsItemRepository _newsItemRepository;
        public NewsItemService(INewsItemRepository newsItemRepository)
        {
            _newsItemRepository = newsItemRepository;
        }
        public IEnumerable<NewsItemDto> GetAllNewsItems(int PageSize, int PageNumber)
        {
            return PageService<NewsItemDto>.PageData(_newsItemRepository.GetAllNewsItems(), PageNumber, PageSize);
        }
        public NewsItemDetailDto GetNewsItemById(int id) 
        {
            var newsItem = _newsItemRepository.GetNewsItemById(id);
            if (newsItem == null) { throw new ResourceNotFoundException($"News item with id {id} was not found."); }
            return newsItem;
        }

    }
}