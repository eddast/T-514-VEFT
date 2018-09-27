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
        /// Gets a list of all category in system
        /// </summary>
        /// <returns>List of all category in system</returns>
        List<Category> GetAllCategories();
    }
}