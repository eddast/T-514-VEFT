using System.Collections.Generic;
using CleanThatCode.Community.Models.Dtos;

namespace CleanThatCode.Community.Repositories.Interfaces
{
    public interface ICommentRepository
    {
         IEnumerable<CommentDto> GetAllCommentsByPostId(int postId);
    }
}