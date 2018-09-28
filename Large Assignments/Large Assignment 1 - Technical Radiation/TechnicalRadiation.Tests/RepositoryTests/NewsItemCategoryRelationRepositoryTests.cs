using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FizzWare.NBuilder;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Implementation;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Tests
{
    /// <summary>
    /// Tests news item to category relation layer
    /// </summary>
    [TestClass]
    public class NewsItemCategoryRelationRepositoryTests
    {
        private INewsItemCategoryRelationRepository _relationRepository;
        private Mock<INewsItemCategoryRelationProvider> _dataProviderMock = new Mock<INewsItemCategoryRelationProvider>();

        /// <summary>
        /// Setup mock relation data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _dataProviderMock.Setup(method => method.GetNewsItemCategoryRelations())
                .Returns(FizzWare.NBuilder.Builder<NewsItemCategoryRelation>
                .CreateListOfSize(5)
                .TheFirst(3).With(x => x.NewsItemId = 1).With(x => x.CategoryId = 1)
                .TheNext(2).With(x => x.NewsItemId = 2).With(x => x.CategoryId = 1)
                .Build().ToList());
            _relationRepository = new NewsItemCategoryRelationRepository(_dataProviderMock.Object);
        }

        /// <summary>
        /// Tests if repository method gets all relations correctly given news item id
        /// </summary>
        [TestMethod]
        public void GetAllNewsItemsCategoryRelationsByNewsItemId_ShouldReturnAListOfLength3()
        {
            var relations = _relationRepository.GetAllNewsItemsCategoryRelationsByNewsItemId(1);
            Assert.AreEqual(3, relations.Count());
        }

        /// <summary>
        /// Tests if repository method gets all relations correctly given category id
        /// </summary>
        [TestMethod]
        public void GetAllNewsItemsCategoryRelationsByCategoryId_ShouldReturnAListOfLength5()
        {
            var relations = _relationRepository.GetAllNewsItemsCategoryRelationsByCategoryId(1);
            Assert.AreEqual(5, relations.Count());
        }

        /// <summary>
        /// Test if getting all relations for news item id that is not in relations list returns empty list
        /// </summary>
        [TestMethod]
        public void GetAllNewsItemsCategoryRelationsByNewsItemId_ShouldReturnEmptyList()
        {
            var relations = _relationRepository.GetAllNewsItemsCategoryRelationsByNewsItemId(3);
            Assert.AreEqual(0, relations.Count());
        }

        /// <summary>
        /// Test if getting all relations for category id that is not in relations list returns empty list
        /// </summary>
        [TestMethod]
        public void GetAllNewsItemsCategoryRelationsByCategoryId_ShouldReturnEmptyList()
        {
            var relations = _relationRepository.GetAllNewsItemsCategoryRelationsByCategoryId(3);
            Assert.AreEqual(0, relations.Count());
        }
    }
}
