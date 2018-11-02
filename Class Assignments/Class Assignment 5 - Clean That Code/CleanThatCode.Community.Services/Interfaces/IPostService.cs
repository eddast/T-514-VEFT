using System.Collections.Generic;
using CleanThatCode.Community.Models.Dtos;

namespace CleanThatCode.Community.Services.Interfaces
{
    public interface IPostService
    {
         IEnumerable<PostDto> GetAllPosts(string titleFilter, string authorFilter);
    }
}