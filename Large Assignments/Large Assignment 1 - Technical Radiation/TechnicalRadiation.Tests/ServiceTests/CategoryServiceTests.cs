using System;
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
    /// Tests exceptions in category service
    /// </summary>
    [TestClass]
    public class CategoryServiceTests
    {
        private ICategoryService _service;
        private Mock<ICategoryRepository> _categoryRepositoryMock= new Mock<ICategoryRepository>();
        private Mock<INewsItemCategoryRelationRepository> _newsItemRelationRepositoryMock = new Mock<INewsItemCategoryRelationRepository>();
        private Mock<INewsItemService> _newsItemServiceMock = new Mock<INewsItemService>();

        /// <summary>
        /// Setup mock data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _service = new CategoryService(_categoryRepositoryMock.Object, _newsItemRelationRepositoryMock.Object, _newsItemServiceMock.Object);
        }

        /// <summary>
        /// Tests if service method throws an exception if category is gotten by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void GetCategoryById_ShouldThrowResourceNotFoundException() => _service.GetCategoryById(3);

        /// <summary>
        /// Tests if service method throws an exception if category is deleted by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void DeleteCategoryById_ShouldThrowResourceNotFoundException() => _service.DeleteCategoryById(3);

        /// <summary>
        /// Tests if service method throws an exception if category is updated by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void UpdateCategoryById_ShouldThrowResourceNotFoundException() => _service.UpdateCategoryById(null, 3);
    }
}