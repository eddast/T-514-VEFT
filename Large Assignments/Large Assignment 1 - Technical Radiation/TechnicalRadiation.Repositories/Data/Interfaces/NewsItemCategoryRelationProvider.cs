using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;

namespace TechnicalRadiation.Repositories.Data
{
    /// <summary>
    /// Serves data of news items belonging to one or more categories from source in system
    /// </summary>
    public interface INewsItemCategoryRelationProvider
    {
        /// <summary>
        /// Gets a list of all news items belonging to one or more categories in system
        /// </summary>
        /// <returns>List of all news items belonging to one or more categories in system</returns>
        List<NewsItemCategoryRelation> GetNewsItemCategoryRelations();
    }
}