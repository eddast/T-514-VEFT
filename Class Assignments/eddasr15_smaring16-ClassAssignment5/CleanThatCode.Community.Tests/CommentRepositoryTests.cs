using System.Collections.Generic;
using System.Linq;
using CleanThatCode.Community.Models.Dtos;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanThatCode.Community.Tests
{
    // It is your job to make those tests pass, by implementing the methods in StringHelpers located in CleanThatCode.Community.Common
    [TestClass]
    public class CommentRepositoryTests
    {
        private CommentRepository _commentRepository;
        private CleanThatCodeDBContextMock _dbContextMock = new CleanThatCodeDBContextMock();

        [TestInitialize]
        public void Initialize()
        {
            _commentRepository = new CommentRepository(_dbContextMock);
        }

        [TestMethod]
        public void GetALlCommentsByPostId_GivenWrongPostId_ShouldReturnNoComments()
        {
            IEnumerable<CommentDto> comments = _commentRepository.GetAllCommentsByPostId(-1);
            Assert.AreEqual(0, comments.Count());
        }

        [TestMethod]
        public void GetALlCommentsByPostId_GivenWrongPostId_ShouldReturnTwoComments()
        {
            IEnumerable<CommentDto> comments = _commentRepository.GetAllCommentsByPostId(1);
            Assert.AreEqual(2, comments.Count());
        }
    }
}