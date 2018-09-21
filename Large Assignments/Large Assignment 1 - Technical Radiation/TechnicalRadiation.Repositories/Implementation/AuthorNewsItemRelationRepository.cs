using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories.Implementation
{
    /// <summary>
    /// Fetches data in system on authors and news item relations
    /// (i.e. information on which authors are authors of which news items)
    /// </summary>
    public class AuthorNewsItemRelationRepository : IAuthorNewsItemRelationRepository
    {
        /// <summary>
        /// Data provider to use to get news items associated with authors
        /// </summary>
        private readonly IAuthorNewsItemRelationsProvider _relationalDataProvider;


        /// <summary>
        /// Initiate data provider
        /// </summary>
        /// <param name="dataProvider">the author data provider to use</param>
        public AuthorNewsItemRelationRepository(IAuthorNewsItemRelationsProvider relationalDataProvider)
        {
            _relationalDataProvider = relationalDataProvider;
        }

        /// <summary>
        /// Gets all relations of authors to news items by author from relational data provider
        /// </summary>
        /// <param name="id">author id</param>
        /// <returns>all relations of authors to news items</returns>
        public IEnumerable<AuthorNewsItemRelation> GetAllAuthorNewsItemsRelationByAuthorId(int id) =>
            _relationalDataProvider.GetAuthorNewsItemRelations().Where(r => r.AuthorId == id);
    }
}