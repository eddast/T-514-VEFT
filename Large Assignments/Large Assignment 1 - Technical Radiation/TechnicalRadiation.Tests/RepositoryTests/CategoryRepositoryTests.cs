// using System;
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
    /// Tests category repository layer
    /// </summary>
    [TestClass]
    public class CategoryRepositoryTests
    {
        private ICategoryRepository _repository;
        private Mock<ICategoryDataProvider> _dataProviderMock = new Mock<ICategoryDataProvider>();

        /// <summary>
        /// Setup mock data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            // Reset mapper for category models
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Category, CategoryDto>(); cfg.CreateMap<Category, CategoryDetailDto>();
            });

            // Build Mock Data of two items with ids 1 and 2 in system
            _dataProviderMock.Setup(method => method.GetAllCategories()).Returns(
                FizzWare.NBuilder.Builder<Category>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1)
                    .TheNext(1).With(x => x.Id = 2)
                    .Build().ToList()
            );
            _repository = new CategoryRepository(_dataProviderMock.Object);
        }

        /// <summary>
        /// Tests if repository method gets the list of all categories correctly
        /// </summary>
        [TestMethod]
        public void GetAllCategories_ShouldReturnAListOfTwo()
        {
            var categories = _repository.GetAllCategories();
            Assert.AreEqual(categories.Count(), 2);
        }

        /// <summary>
        /// Tests if repository method gets category correctly by id
        /// </summary>
        [TestMethod]
        public void GetCategoryById_ShouldReturnCategoryWithId1()
        {
            var category = _repository.GetCategoryById(1);
            Assert.AreEqual(category.Id, 1);
        }

        /// <summary>
        /// Tests if repository method returns null if category is gotten by some id not in list
        /// </summary>
        [TestMethod]
        public void GetCategoryById_ShouldReturnNull()
        {
            var category = _repository.GetCategoryById(3);
            Assert.IsNull(category);
        }
    }
}