using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.Extensions;
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

        /// <summary>
        /// Returns list of all categories with appropriate link relations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            foreach(var c in categories) c.AddReferences();
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
            category.AddReferences();
            return category;
        }
    }
}