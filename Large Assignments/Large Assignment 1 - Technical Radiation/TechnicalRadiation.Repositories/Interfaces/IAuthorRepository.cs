using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Repositories.Interfaces
{
    /// <summary>
    /// Gets author data from data provider
    /// </summary>
    public interface IAuthorRepository
    {
        /// <summary>
        /// Gets all authors from data provider
        /// </summary>
        /// <returns>List of all authors</returns>
        IEnumerable<AuthorDto> GetAllAuthors();

        /// <summary>
        /// Gets a single author by their Id from data provider
        /// </summary>
        /// <param name="id">Id associated with author to get</param>
        /// <returns>A single author by id or throws not found error</returns>
        AuthorDetailDto GetAuthorById(int id);
        
    }
}