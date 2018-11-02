using System.Collections.Generic;
using System.Linq;
using CleanThatCode.Community.Models.Dtos;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Interfaces;

namespace CleanThatCode.Community.Repositories.Implementations
{
    public class PostRepository : IPostRepository
    {
        private readonly ICleanThatCodeDbContext _dbContext;

        public PostRepository(ICleanThatCodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PostDto> GetAllPosts(string titleFilter, string authorFilter)
        {
            return _dbContext.Posts.Where(p => p.Title.Contains(titleFilter) && p.Author.Contains(authorFilter)).Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                Author = p.Author,
                Message = p.Message,
                Created = p.Created,
                NumberOfLikes = p.NumberOfLikes
            });
        }
    }
}