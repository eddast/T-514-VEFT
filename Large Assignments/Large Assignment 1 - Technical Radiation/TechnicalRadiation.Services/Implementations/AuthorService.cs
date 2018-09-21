using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    /// <summary>
    /// Gets author data from repository and conducts link relations for honoring HATEOAS
    /// </summary>
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// Author repository
        /// </summary>
        private readonly IAuthorRepository _authorRepository;

        /// <summary>
        /// Initialize repository
        /// </summary>
        /// <param name="authorRepository">Which implementation of author repository to use</param>
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        /// <summary>
        /// Gets a list of all authors with appropriate link relations
        /// </summary>
        /// <returns>List of author dtos</returns>
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            foreach(var a in authors) a.AddReferences();
            return authors;
        }
        
        /// <summary>
        /// Gets a single author by id with appropriate link relations, throws exception if author not found in system by id
        /// </summary>
        /// <param name="id">Id associated with some author in system</param>
        /// <returns>A single author detail dto</returns>
        public AuthorDetailDto GetAuthorById(int id) 
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) { throw new ResourceNotFoundException($"Author with id {id} was not found."); }
            author.AddReferences();
            return author;
        }
        
    }
}