using System.Collections.Generic;
using CleanThatCode.Community.Models.Dtos;

namespace CleanThatCode.Community.Repositories.Interfaces
{
    public interface IPostRepository
    {
        /// <summary>
        /// Gets all posts within the database
        /// </summary>
        /// <param name="titleFilter">A string value used to filter the title of post</param>
        /// <param name="authorFilter">A string value used to filter the author of post</param>
        /// <returns>A filtered list of posts</returns>
         IEnumerable<PostDto> GetAllPosts(string titleFilter, string authorFilter);
    }
}