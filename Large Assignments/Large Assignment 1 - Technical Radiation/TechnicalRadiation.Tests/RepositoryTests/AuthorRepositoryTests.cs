using System;
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
    /// Tests author repository layer
    /// </summary>
    [TestClass]
    public class AuthorRepositoryTests
    {
        private IAuthorRepository _repository;
        private Mock<IAuthorDataProvider> _dataProviderMock = new Mock<IAuthorDataProvider>();

        /// <summary>
        /// Setup mock data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            // Reset mapper for author models
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Author, AuthorDto>(); cfg.CreateMap<Author, AuthorDetailDto>();
            });

            // Build Mock Data of two authors with ids 1 and 2 in system
            _dataProviderMock.Setup(method => method.GetAllAuthors()).Returns(
                FizzWare.NBuilder.Builder<Author>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1)
                    .TheNext(1).With(x => x.Id = 2)
                    .Build().ToList()
            );
            _repository = new AuthorRepository(_dataProviderMock.Object);
        }

        /// <summary>
        /// Tests if repository method gets the list of all authors correctly
        /// </summary>
        [TestMethod]
        public void GetAllAuthors_ShouldReturnAListOfTwo()
        {
            var authors = _repository.GetAllAuthors();
            Assert.AreEqual(authors.Count(), 2);
        }

        /// <summary>
        /// Tests if repository method gets author correctly by id
        /// </summary>
        [TestMethod]
        public void GetAuthorById_ShouldReturnAuthorWithId1()
        {
            var author = _repository.GetAuthorById(1);
            Assert.AreEqual(author.Id, 1);
        }

        /// <summary>
        /// Tests if repository method returns null if author is gotten by some id not in list
        /// </summary>
        [TestMethod]
        public void GetAuthorById_ShouldReturnNull()
        {
            var author = _repository.GetAuthorById(3);
            Assert.IsNull(author);
        }
    }
}