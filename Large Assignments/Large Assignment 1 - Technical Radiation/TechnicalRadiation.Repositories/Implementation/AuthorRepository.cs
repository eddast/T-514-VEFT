using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories
{
    /// <summary>
    /// Gets author data from data provider
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        /// <summary>
        /// Data provider to use to get authors
        /// </summary>
        private readonly IAuthorDataProvider _dataProvider;

        /// <summary>
        /// Initiate data provider
        /// </summary>
        /// <param name="dataProvider">the author data provider to use</param>
        public AuthorRepository(IAuthorDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Gets all authors from data provider
        /// </summary>
        /// <returns>List of all authors</returns>
        public IEnumerable<AuthorDto> GetAllAuthors() => Mapper.Map<IEnumerable<AuthorDto>>(_dataProvider.GetAuthors());

        /// <summary>
        /// Gets a single author by their Id from data provider
        /// </summary>
        /// <param name="id">Id associated with author to get</param>
        /// <returns>A single author by id or throws not found error</returns>
        public AuthorDetailDto GetAuthorById(int id) => Mapper.Map<AuthorDetailDto>(_dataProvider.GetAuthors().FirstOrDefault(a => a.Id == id));
    }
}