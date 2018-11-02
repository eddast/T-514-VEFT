using System.Collections.Generic;
using CleanThatCode.Community.Models.Dtos;
using CleanThatCode.Community.Repositories.Interfaces;
using CleanThatCode.Community.Services.Interfaces;

namespace CleanThatCode.Community.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<CommentDto> GetAllCommentByPostId(int postId) => _commentRepository.GetAllCommentsByPostId(postId);
    }
}