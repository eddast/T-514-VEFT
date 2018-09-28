using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    /// <summary>
    /// Gets author data from repository in appropriate form
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Gets a list of all authors in system
        /// </summary>
        /// <returns>List of author dtos</returns>
        IEnumerable<AuthorDto> GetAllAuthors();
        
        /// <summary>
        /// Gets a single author by id, throws exception if author not found in system by id
        /// </summary>
        /// <param name="id">Id associated with some author in system</param>
        /// <returns>A single author detail dto</returns>
        AuthorDetailDto GetAuthorById(int id);

        /// <summary>
        /// Gets a single author by id with appropriate link relations
        /// </summary>
        /// <param name="id">Id associated with some author in system</param>
        /// <returns>List of news items associated with author</returns>
       IEnumerable<NewsItemDto> GetNewsItemsByAuthor(int id);

        /// <summary>
        /// Creates new author to system
        /// </summary>
        /// <param name="author">new author to add</param>
        /// <returns>the id of new author</returns>
        int CreateAuthor(AuthorInputModel author);

        /// <summary>
        /// Updates author by id
        /// </summary>
        /// <param name="author">new information on author to switch to</param>
        /// <param name="id">id of author to update</param>
        void UpdateAuthorById(AuthorInputModel author, int id);

        /// <summary>
        /// Deletes author by id
        /// </summary>
        /// <param name="id">id of author to delete</param>
        void DeleteAuthorById(int id);

        /// <summary>
        /// Links a news item to author by their ids
        /// </summary>
        /// <param name="authorId">id of author to link to news item</param>
        /// <param name="newsItemId">id of news item to link to author</param>
        void LinkNewsItemToAuthor(int authorId, int newsItemId);
        
    }
}