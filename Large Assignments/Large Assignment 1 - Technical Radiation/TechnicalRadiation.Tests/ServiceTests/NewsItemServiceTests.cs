// using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FizzWare.NBuilder;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Repositories.Implementation;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;

namespace TechnicalRadiation.Tests
{
    /// <summary>
    /// Tests exception in news item service
    /// </summary>
    [TestClass]
    public class NewsItemServiceTests
    {
        private INewsItemService _service;
        private Mock<INewsItemRepository> _newsItemRepositoryMock = new Mock<INewsItemRepository>();
        private Mock<INewsItemCategoryRelationRepository> _categoryRelationRepositoryMock = new Mock<INewsItemCategoryRelationRepository>();
        private Mock<IAuthorNewsItemRelationRepository> _authorRelationRepositoryMock = new Mock<IAuthorNewsItemRelationRepository>();

        /// <summary>
        /// Setup mock data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _service = new NewsItemService(_newsItemRepositoryMock.Object, _categoryRelationRepositoryMock.Object, _authorRelationRepositoryMock.Object);
        }

        /// <summary>
        /// Tests if service method throws an exception if news item is gotten by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void GetNewsItemById_ShouldThrowResourceNotFoundException() => _service.GetNewsItemById(3);

        /// <summary>
        /// Tests if service method throws an exception if news item is deleted by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void DeleteNewsItemById_ShouldThrowResourceNotFoundException() => _service.DeleteNewsItemById(3);

        /// <summary>
        /// Tests if service method throws an exception if news item is updated by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void UpdateNewsItemById_ShouldThrowResourceNotFoundException() => _service.UpdateNewsItemById(null, 3);
    }
}