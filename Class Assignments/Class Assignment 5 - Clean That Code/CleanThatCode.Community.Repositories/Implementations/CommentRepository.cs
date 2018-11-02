using System.Collections.Generic;
using System.Linq;
using CleanThatCode.Community.Models.Dtos;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Interfaces;

namespace CleanThatCode.Community.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ICleanThatCodeDbContext _dbContext;

        public CommentRepository(ICleanThatCodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CommentDto> GetAllCommentsByPostId(int postId)
        {
            return _dbContext.Comments.ToList().Where(c => c.PostId == postId).Select(c => new CommentDto
            {
                Id = c.Id,
                PostId = c.PostId,
                Author = c.Author,
                Message = c.Message,
                Created = c.Created
            });
        }
    }
}