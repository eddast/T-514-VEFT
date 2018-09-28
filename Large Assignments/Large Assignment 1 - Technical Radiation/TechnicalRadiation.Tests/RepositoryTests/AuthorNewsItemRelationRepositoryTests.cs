using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FizzWare.NBuilder;
using TechnicalRadiation.Repositories.Implementation;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Tests
{
    /// <summary>
    /// Tests author to news item relations
    /// </summary>
    [TestClass]
    public class AuthorNewsItemRelationRepositoryTests
    {
        private IAuthorNewsItemRelationRepository _relationRepository;
        private Mock<IAuthorNewsItemRelationsProvider> _dataProviderMock = new Mock<IAuthorNewsItemRelationsProvider>();

        /// <summary>
        /// Setup mock relation data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _dataProviderMock.Setup(method => method.GetAuthorNewsItemRelations())
                .Returns(FizzWare.NBuilder.Builder<AuthorNewsItemRelation>
                .CreateListOfSize(5)
                .TheFirst(3).With(x => x.AuthorId = 1).With(x => x.NewsItemId = 1)
                .TheNext(2).With(x => x.AuthorId = 2).With(x => x.NewsItemId = 1)
                .Build().ToList());
            _relationRepository = new AuthorNewsItemRelationRepository(_dataProviderMock.Object);
        }

        /// <summary>
        /// Tests if repository method gets all relations correctly given author id
        /// </summary>
        [TestMethod]
        public void GetAllNewsItemsForAuthor_ShouldReturnAListOfLength3()
        {
            var relations = _relationRepository.GetAllNewsItemsForAuthor(1);
            Assert.AreEqual(3, relations.Count());
        }

        /// <summary>
        /// Tests if repository method gets all relations correctly given news item id
        /// </summary>
        [TestMethod]
        public void GetAuthorsForNewsItems_ShouldReturnAListOfLength5()
        {
            var relations = _relationRepository.GetAuthorsForNewsItems(1);
            Assert.AreEqual(5, relations.Count());
        }

        /// <summary>
        /// Test if getting all relations for author id that is not in relations list returns empty list
        /// </summary>
        [TestMethod]
        public void GetAllNewsItemsForAuthor_ShouldReturnEmptyList()
        {
            var relations = _relationRepository.GetAllNewsItemsForAuthor(3);
            Assert.AreEqual(0, relations.Count());
        }

        /// <summary>
        /// Test if getting all relations for news item id that is not in relations list returns empty list
        /// </summary>
        [TestMethod]
        public void GetAuthorsForNewsItems_ShouldReturnEmptyList()
        {
            var relations = _relationRepository.GetAuthorsForNewsItems(3);
            Assert.AreEqual(0, relations.Count());
        }
    }
}
