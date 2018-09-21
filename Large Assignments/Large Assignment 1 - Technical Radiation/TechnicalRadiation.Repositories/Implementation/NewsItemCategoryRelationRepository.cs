using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories.Implementation
{
    /// <summary>
    /// Fetches data in system on news item and category relations
    /// (i.e. which news items belong to which categories)
    /// </summary>
    public class NewsItemCategoryRelationRepository : INewsItemCategoryRelationRepository
    {
        /// <summary>
        /// Data provider to use to get news items associated with authors
        /// </summary>
        private readonly INewsItemCategoryRelationProvider _relationalDataProvider;


        /// <summary>
        /// Initiate data provider
        /// </summary>
        /// <param name="dataProvider">the author data provider to use</param>
        public NewsItemCategoryRelationRepository(INewsItemCategoryRelationProvider relationalDataProvider)
        {
            _relationalDataProvider = relationalDataProvider;
        }

        /// <summary>
        /// Gets all relations of news items to categories by news item from relational data provider
        /// </summary>
        /// <param name="id">author id</param>
        /// <returns>all relations of news items to categories</returns>
        public IEnumerable<NewsItemCategoryRelation> GetAllNewsItemsCategoryRelationsByNewsItemId(int id) =>
            _relationalDataProvider.GetNewsItemCategoryRelations().Where(r => r.NewsItemId == id);
    }
}