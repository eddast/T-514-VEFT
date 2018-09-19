using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories
{
    public class NewsItemRepository: INewsItemRepository
    {
        private readonly INewsItemDataProvider _dataProvider;
        public NewsItemRepository(INewsItemDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public IEnumerable<NewsItemDto> GetAllNewsItems() => Mapper.Map<IEnumerable<NewsItemDto>>(_dataProvider.GetNewsItems());
        public NewsItemDetailDto GetNewsItemById(int id) => Mapper.Map<NewsItemDetailDto>(_dataProvider.GetNewsItems().FirstOrDefault(n => n.Id == id));
    }
}
