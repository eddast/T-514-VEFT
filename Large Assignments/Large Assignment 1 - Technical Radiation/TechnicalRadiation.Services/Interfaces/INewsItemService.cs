using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface INewsItemService
    {
        IEnumerable<NewsItemDto> GetAllNewsItems(int pageNumber, int pageSize);
        NewsItemDetailDto GetNewsItemById(int id);
    }
}