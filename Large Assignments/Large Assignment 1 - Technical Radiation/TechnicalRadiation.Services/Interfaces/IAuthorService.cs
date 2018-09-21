using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

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
        /// Gets a single author by id with appropriate link relations,
        /// throws exception if author not found in system by id
        /// </summary>
        /// <param name="id">Id associated with some author in system</param>
        /// <returns>List of news items associated with author</returns>
       IEnumerable<NewsItemDto> GetNewsItemsByAuthor(int id);
        
    }
}