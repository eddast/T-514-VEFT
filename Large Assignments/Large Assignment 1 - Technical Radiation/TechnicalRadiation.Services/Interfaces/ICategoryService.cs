using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Returns list of all categories with appropriate link relations
        /// </summary>
        /// <returns>list of all categories with appropriate link relations</returns>
        IEnumerable<CategoryDto> GetAllCategories();

        /// <summary>
        /// Gets a single category with appropriate link relations, throws exception if category not found in system by id
        /// </summary>
        /// <param name="id">id associated with a category in system</param>
        /// <returns>single category with appropriate link relations</returns>
        CategoryDetailDto GetCategoryById(int id);
        
        /// <summary>
        /// Creates new category and adds to system
        /// </summary>
        /// <param name="newsItem">new category to add</param>
        /// <returns>the id of new category</returns>
        int CreateCategory(CategoryInputModel category);

        /// <summary>
        /// Updates category by id
        /// </summary>
        /// <param name="category">new information on category to switch to</param>
        /// <param name="id">id of category to update</param>
        void UpdateCategoryById(CategoryInputModel category, int id);

        /// <summary>
        /// Deletes category by id
        /// </summary>
        /// <param name="id">id of category to delete</param>
        void DeleteCategoryById(int id);

        /// <summary>
        /// Links a news item to category by their ids
        /// </summary>
        /// <param name="categoryId">id of category to link to news item</param>
        /// <param name="newsItemId">id of news item to link to category</param>
        void LinkNewsItemToCategory(int categoryId, int newsItemId);
    }
}