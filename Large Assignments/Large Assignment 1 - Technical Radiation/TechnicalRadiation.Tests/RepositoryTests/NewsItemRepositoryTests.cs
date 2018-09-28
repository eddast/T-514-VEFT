// // using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FizzWare.NBuilder;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Repositories.Implementation;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Tests
{
    /// <summary>
    /// Tests news item repository layer
    /// </summary>
    [TestClass]
    public class NewsItemRepositoryTests
    {
        private INewsItemRepository _repository;
        private Mock<INewsItemDataProvider> _dataProviderMock = new Mock<INewsItemDataProvider>();

        /// <summary>
        /// Setup mock data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            // Reset mapper for news item models
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<NewsItem, NewsItemDto>(); cfg.CreateMap<NewsItem, NewsItemDetailDto>();
            });

            // Build Mock Data of two items with ids 1 and 2 in system
            _dataProviderMock.Setup(method => method.GetAllNewsItems()).Returns(
                FizzWare.NBuilder.Builder<NewsItem>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1)
                    .TheNext(1).With(x => x.Id = 2)
                    .Build().ToList()
            );
            _repository = new NewsItemRepository(_dataProviderMock.Object);
        }

        /// <summary>
        /// Tests if repository method gets the list of all news items correctly
        /// </summary>
        [TestMethod]
        public void GetAllNewsItems_ShouldReturnAListOfTwo()
        {
            var newsItem = _repository.GetAllNewsItems();
            Assert.AreEqual(newsItem.Count(), 2);
        }

        /// <summary>
        /// Tests if repository method gets news items correctly by id
        /// </summary>
        [TestMethod]
        public void GetNewsItemById_ShouldReturnNewsItemWithId1()
        {
            var newsItem = _repository.GetNewsItemById(1);
            Assert.AreEqual(newsItem.Id, 1);
        }

        /// <summary>
        /// Tests if repository method returns null if news item is gotten by some id not in list
        /// </summary>
        [TestMethod]
        public void GetNewsItemById_ShouldReturnNull()
        {
            var newsItem = _repository.GetNewsItemById(3);
            Assert.IsNull(newsItem);
        }
    }
}