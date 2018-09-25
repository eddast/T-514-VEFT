using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Interfaces
{
    /// <summary>
    /// Fetches data in system on authors and news item relations
    /// (i.e. information on which authors are authors of which news items)
    /// </summary>
    public interface IAuthorNewsItemRelationRepository
    {
        /// <summary>
        /// Gets all relations of authors to news items by author from relational data provider
        /// </summary>
        /// <param name="id">author id</param>
        /// <returns>all relations of specific author to news items</returns>
        IEnumerable<AuthorNewsItemRelation> GetAllNewsItemsForAuthor(int authorId);

        /// <summary>
        /// Gets all relations of news item to authors by news item id from relational data provider
        /// </summary>
        /// <param name="id">news item id</param>
        /// <returns>all relations of specific news item to authors</returns>
        IEnumerable<AuthorNewsItemRelation> GetAuthorsForNewsItems(int newsItemId);

        /// <summary>
        /// Deletes relation from relational list
        /// </summary>
        /// <param name="relation">the relation to delete</param>
        void DeleteRelation(AuthorNewsItemRelation relation);

        /// <summary>
        /// Deletes relation from relational list
        /// </summary>
        /// <param name="relation">the relation to delete</param>
        void AddRelation(AuthorNewsItemRelation relation);
    }
}