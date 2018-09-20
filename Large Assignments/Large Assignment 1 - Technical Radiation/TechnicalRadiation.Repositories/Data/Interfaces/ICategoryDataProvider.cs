using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data.Interfaces
{
    /// <summary>
    /// Serves data from source in system
    /// </summary>
    public interface ICategoryDataProvider
    {
        /// <summary>
        /// Returns a list of all categories in system
        /// </summary>
        /// <returns>List of all categories in system</returns>
         List<Category> GetCategories();
    }
}