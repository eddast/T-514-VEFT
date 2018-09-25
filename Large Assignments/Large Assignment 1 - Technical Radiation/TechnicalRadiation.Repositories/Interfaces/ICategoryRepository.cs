using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.InputModels;

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

        /// <summary>
        /// Creates new category and adds to data
        /// </summary>
        /// <param name="newsItem">category to add to data</param>
        /// <returns>the id of the new news item</returns>
        int CreateCategory(CategoryInputModel category);

        /// <summary>
        /// Updates category by id
        /// </summary>
        /// <param name="category">new category values to set to old category</param>
        /// <param name="id">id of category to update</param>
        void UpdateCategoryById(CategoryInputModel category, int id);

        /// <summary>
        /// Deletes category from system
        /// </summary>
        /// <param name="id">id of the category to delete from system</param>
        void DeleteCategory(int id);
        
    }
}