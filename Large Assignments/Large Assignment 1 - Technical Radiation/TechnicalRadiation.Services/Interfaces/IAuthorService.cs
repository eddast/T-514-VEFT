using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        AuthorDetailDto GetAuthorById(int id);
        
    }
}