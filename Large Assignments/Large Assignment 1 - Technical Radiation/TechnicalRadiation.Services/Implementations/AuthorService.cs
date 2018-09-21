using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.Extensions;
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
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            foreach(var a in authors) a.AddReferences();
            return authors;
        }
        
        public AuthorDetailDto GetAuthorById(int id) 
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) { throw new ResourceNotFoundException($"Author with id {id} was not found."); }
            author.AddReferences();
            return author;
        }
        
    }
}