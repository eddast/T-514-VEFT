using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        AuthorDetailDto GetAuthorById(int id);
        
    }
}