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
    /// Tests exceptions in author service
    /// </summary>
    [TestClass]
    public class AuthorServiceTests
    {
        private IAuthorService _service;
        private Mock<IAuthorRepository> _authorRepositoryMock= new Mock<IAuthorRepository>();
        private Mock<IAuthorNewsItemRelationRepository> _newsItemRelationRepositoryMock = new Mock<IAuthorNewsItemRelationRepository>();
        private Mock<INewsItemService> _newsItemServiceMock = new Mock<INewsItemService>();

        /// <summary>
        /// Setup mock data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _service = new AuthorService(_authorRepositoryMock.Object, _newsItemRelationRepositoryMock.Object, _newsItemServiceMock.Object);
        }

        /// <summary>
        /// Tests if service method throws an exception if author is gotten by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void GetAuthorById_ShouldThrowResourceNotFoundException() => _service.GetAuthorById(3);

        /// <summary>
        /// Tests if service method throws an exception if author is deleted by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void DeleteAuthorById_ShouldThrowResourceNotFoundException() => _service.DeleteAuthorById(3);

        /// <summary>
        /// Tests if service method throws an exception if author is updated by some id not in list
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void UpdateAuthorById_ShouldThrowResourceNotFoundException() => _service.UpdateAuthorById(null, 3);
    }
}