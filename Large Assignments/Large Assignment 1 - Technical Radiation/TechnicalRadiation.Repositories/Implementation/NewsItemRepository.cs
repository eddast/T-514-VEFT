using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories
{
    /// <summary>
    /// Gets news item data from data provider
    /// </summary>
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
            Mapper.Map<IEnumerable<NewsItemDto>>(_dataProvider.GetAllNewsItems().OrderByDescending(n => n.PublishDate));
        
        /// <summary>
        /// Gets a single news item by id
        /// </summary>
        /// <param name="id">id of news item to get</param>
        /// <typeparam name="NewsItemDetailDto">Single news item detail information</typeparam>
        /// <returns>Single news item detail information to return</returns>
        public NewsItemDetailDto GetNewsItemById(int id) =>
            Mapper.Map<NewsItemDetailDto>(_dataProvider.GetAllNewsItems().FirstOrDefault(n => n.Id == id));
        
        /// <summary>
        /// Creates new news item and adds to data
        /// </summary>
        /// <param name="newsItem">news item to add to data</param>
        /// <returns>the id of the new news item</returns>
        public int CreateNewsItem(NewsItemInputModel newsItem)
        {
            // Get highest id in list and add one to ensure unique id
            var newNewsItemId = _dataProvider.GetAllNewsItems().OrderByDescending(item => item.Id).First().Id + 1;
            var newNewsItem = Mapper.Map<NewsItem>(newsItem);
            newNewsItem.Id = newNewsItemId;
            _dataProvider.GetAllNewsItems().Add(newNewsItem);
            
            return newNewsItemId;
        }

        /// <summary>
        /// Updates news item by id
        /// </summary>
        /// <param name="newsItem">new news item values to set to old news item</param>
        /// <param name="id">id of news item to update</param>
        public void UpdateNewsItemById(NewsItemInputModel newsItem, int id)
        {
            // Update properties for entity model
            var oldNewsItem = _dataProvider.GetAllNewsItems().FirstOrDefault(n => n.Id == id);
            oldNewsItem.Title = newsItem.Title;
            oldNewsItem.ImgSource = newsItem.ImgSource;
            oldNewsItem.ShortDescription = newsItem.ShortDescription;
            oldNewsItem.LongDescription = newsItem.LongDescription;
            if(newsItem.PublishDate.HasValue) {
                oldNewsItem.PublishDate = newsItem.PublishDate.Value;
            }
            oldNewsItem.ModifiedBy = "SystemAdmin";
            oldNewsItem.ModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Deletes news item from system
        /// </summary>
        /// <param name="id">the id of news item to delete from system</param>
        public void DeleteNewsItem(int id)
        {
            var newsItems = _dataProvider.GetAllNewsItems();
            var toRemove = newsItems.FirstOrDefault(n => n.Id == id);
            newsItems.Remove(toRemove);
        }
    }
}
