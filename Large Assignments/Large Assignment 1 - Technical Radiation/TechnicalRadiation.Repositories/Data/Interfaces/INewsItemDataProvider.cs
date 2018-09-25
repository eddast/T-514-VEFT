using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data.Interfaces
{
    /// <summary>
    /// Serves data from source in system
    /// </summary>
    public interface INewsItemDataProvider
    {
        /// <summary>
        /// Gets a list of all news items in system
        /// </summary>
        /// <returns>List of all news items in system</returns>
        List<NewsItem> GetAllNewsItems();
    }
}