using System.Collections.Generic;
using System.Linq;
using CleanThatCode.Community.Models.Dtos;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Implementations;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CleanThatCode.Community.Tests
{
    [TestClass]
    public class PostRepositoryTests
    {
        private PostRepository _postRepository;
        private Mock<ICleanThatCodeDbContext> _dbContextMock = new Mock<ICleanThatCodeDbContext>();

        [TestInitialize]
        public void Initialize()
        {
             _dbContextMock.Setup(method => method.Posts)
                .Returns(FizzWare.NBuilder.Builder<Post>
                .CreateListOfSize(3)
                .TheFirst(2).With(x => x.Title = "Grayskull").With(x => x.Author = "He-Man")
                .TheNext(1).With(x => x.Title = "Hack the planet").With(x => x.Author = "Richard Stallman")
                .Build());
            _postRepository = new PostRepository(_dbContextMock.Object);
        }

        [TestMethod]
        public void GetAllPosts_NoFilter_ShouldContainAListOfThree()
        {
            IEnumerable<PostDto> posts = _postRepository.GetAllPosts("","");
            Assert.AreEqual(3, posts.Count());
        }
        
        [TestMethod]
        public void GetAllPosts_FilteredByTitle_ShouldContainAListOfTwo()
        {
            IEnumerable<PostDto> posts = _postRepository.GetAllPosts("Grayskull","");
            Assert.AreEqual(2, posts.Count());
        }

        [TestMethod]
        public void GetAllPosts_FilteredByTitle_ShouldContainAListOfOne()
        {
            IEnumerable<PostDto> posts = _postRepository.GetAllPosts("","Stallman");
            Assert.AreEqual(1, posts.Count());
        }
    }
}