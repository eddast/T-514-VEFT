using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.InputModels;

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

        /// <summary>
        /// Creates new author and adds to data
        /// </summary>
        /// <param name="author">author to add to data</param>
        /// <returns>the id of the new author</returns>
        int CreateAuthor(AuthorInputModel author);

        /// <summary>
        /// Updates author by id
        /// </summary>
        /// <param name="category">new author values to set to old author</param>
        /// <param name="id">id of author to update</param>
        void UpdateAuthorById(AuthorInputModel author, int id);

        /// <summary>
        /// Deletes author from system
        /// </summary>
        /// <param name="id">the id of the author to delete from system</param>
        void DeleteAuthorById(int id);
<<<<<<< HEAD
=======
        
>>>>>>> 994237b5d7de418430440944ce00dd08a4f6939a
    }
}