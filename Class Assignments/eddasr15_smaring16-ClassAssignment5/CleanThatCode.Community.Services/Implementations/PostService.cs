using System.Collections.Generic;
using CleanThatCode.Community.Models.Dtos;
using CleanThatCode.Community.Repositories.Interfaces;
using CleanThatCode.Community.Services.Interfaces;

namespace CleanThatCode.Community.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<PostDto> GetAllPosts(string titleFilter, string authorFilter) => _postRepository.GetAllPosts(titleFilter, authorFilter);
    }
}