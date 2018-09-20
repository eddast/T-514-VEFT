using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IAuthorDataProvider _dataProvider;
        public AuthorRepository(IAuthorDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public IEnumerable<AuthorDto> GetAllAuthors() => Mapper.Map<IEnumerable<AuthorDto>>(_dataProvider.GetAuthors());

        public AuthorDetailDto GetAuthorsById(int id) => Mapper.Map<AuthorDetailDto>(_dataProvider.GetAuthors().FirstOrDefault(a => a.Id == id));
    }
}