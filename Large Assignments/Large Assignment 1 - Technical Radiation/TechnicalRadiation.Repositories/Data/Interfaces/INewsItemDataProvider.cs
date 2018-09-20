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
        /// Returns list of all news items in system
        /// </summary>
        /// <returns>list of all news items in system</returns>
        List<NewsItem> GetNewsItems();
    }
}