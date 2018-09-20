using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Repositories.Interfaces
{
    /// <summary>
    /// Gets category data from data provider
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Gets all categories from data provider
        /// </summary>
        /// <returns>list of all categories</returns>
        IEnumerable<CategoryDto> GetAllCategories();

        /// <summary>
        /// Gets a single category by Id
        /// </summary>
        /// <param name="id">Id associated with category to get</param>
        /// <returns>a single category detail information by id or throws not found error</returns>
        CategoryDetailDto GetCategoryById(int id);
        
    }
}