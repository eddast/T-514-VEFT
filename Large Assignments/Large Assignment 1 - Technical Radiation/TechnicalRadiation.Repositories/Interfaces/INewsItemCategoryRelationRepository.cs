using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Interfaces
{
    /// <summary>
    /// Fetches data in system on news item and category relations
    /// (i.e. which news items belong to which categories)
    /// </summary>
    public interface INewsItemCategoryRelationRepository
    {
        /// <summary>
        /// Gets all relations of news items to categories by news item from relational data provider
        /// </summary>
        /// <param name="id">news item id</param>
        /// <returns>all relations of news items to categories</returns>
        IEnumerable<NewsItemCategoryRelation>  GetAllNewsItemsCategoryRelationsByNewsItemId(int id);

        /// <summary>
        /// Gets all relations of news items to categories by category id from relational data provider
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns>all relations of news items to categories</returns>
        IEnumerable<NewsItemCategoryRelation> GetAllNewsItemsCategoryRelationsByCategoryId(int id);

        /// <summary>
        /// Deletes relation from relational list
        /// </summary>
        /// <param name="relation">the relation to delete</param>
        void DeleteRelation(NewsItemCategoryRelation relation);
<<<<<<< HEAD

        /// <summary>
        /// Deletes relation from relational list
        /// </summary>
        /// <param name="relation">the relation to delete</param>
        void AddRelation(NewsItemCategoryRelation relation);
=======
>>>>>>> 994237b5d7de418430440944ce00dd08a4f6939a
    }
}