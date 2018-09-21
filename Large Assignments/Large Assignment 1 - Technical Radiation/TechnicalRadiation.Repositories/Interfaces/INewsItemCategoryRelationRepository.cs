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
        IEnumerable<NewsItemCategoryRelation>  GetAllNewsItemsCategoryRelationsByNewsItemId(int id);
    }
}