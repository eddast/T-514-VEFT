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
        IEnumerable<AuthorNewsItemRelation> GetAllNewsItemsForAuthor(int authorId);
        IEnumerable<AuthorNewsItemRelation> GetAuthorsForNewsItems(int newsItemId);
    }
}