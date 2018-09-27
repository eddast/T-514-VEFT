using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    /// <summary>
    /// Gets category data from repository and conducts link relations for honoring HATEOAS
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Category repository
        /// </summary>
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initialize repository
        /// </summary>
        /// <param name="categoryRepository">Which implementation of category repository to use</param>
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public int CreateCategory(CategoryInputModel category)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns list of all categories with appropriate link relations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            foreach(var c in categories) c.AddReferences(c.Id);
            return categories;
        }

        /// <summary>
        /// Gets a single category with appropriate link relations, throws exception if category not found in system by id
        /// </summary>
        /// <param name="id">id associated with a category in system</param>
        /// <returns></returns>
        public CategoryDetailDto GetCategoryById(int id) 
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null) { throw new ResourceNotFoundException($"Author with id {id} was not found."); }
            category.AddReferences(category.Id);
            return category;
        }

        /// <summary>
        /// Updates category by id
        /// </summary>
        /// <param name="category">new information on category to switch to</param>
        /// <param name="id">id of category to update</param>
        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            // TODO!!
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes category by id
        /// </summary>
        /// <param name="id">id of category to delete</param>
        public void DeleteCategoryById(int id)
        {
            // TODO!!
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Links a news item to category by their ids
        /// </summary>
        /// <param name="categoryId">id of category to link to news item</param>
        /// <param name="newsItemId">id of news item to link to category</param>
        public void LinkNewsItemToCategory(int categoryId, int newsItemId)
        {
            // TODO !!
            throw new System.NotImplementedException();
        }
    }
}