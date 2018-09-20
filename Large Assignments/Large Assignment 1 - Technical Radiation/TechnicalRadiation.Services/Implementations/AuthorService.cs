using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public IEnumerable<AuthorDto> GetAllAuthors() => _authorRepository.GetAllAuthors();
        public AuthorDetailDto GetAuthorById(int id) 
        {
            var author = _authorRepository.GetAuthorsById(id);
            if (author == null) { throw new ResourceNotFoundException($"Author with id {id} was not found."); }
            return author;
        }
        
    }
}