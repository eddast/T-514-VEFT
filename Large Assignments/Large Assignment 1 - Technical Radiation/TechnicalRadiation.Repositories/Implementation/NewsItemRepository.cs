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
        /// <summary>
        /// Data provider to use to get news items
        /// </summary>
        private readonly INewsItemDataProvider _dataProvider;

        /// <summary>
        /// Initiate data provider
        /// </summary>
        /// <param name="dataProvider">the news item data provider to use</param>
        public NewsItemRepository(INewsItemDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Returns list of all news items in descending order
        /// </summary>
        /// <returns>list of all news items in descending order</returns>
        public IEnumerable<NewsItemDto> GetAllNewsItems() =>
            Mapper.Map<IEnumerable<NewsItemDto>>(_dataProvider.GetNewsItems().OrderByDescending(n => n.PublishDate));
        
        /// <summary>
        /// Gets a single news item by id
        /// </summary>
        /// <param name="id">id of news item to get</param>
        /// <typeparam name="NewsItemDetailDto">Single news item detail information</typeparam>
        /// <returns>Single news item detail information to return</returns>
        public NewsItemDetailDto GetNewsItemById(int id) =>
            Mapper.Map<NewsItemDetailDto>(_dataProvider.GetNewsItems().FirstOrDefault(n => n.Id == id));
    }
}
