using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IEnumerable<CategoryDto> GetAllCategories() => _categoryRepository.GetAllCategories();
        public CategoryDetailDto GetCategoryById(int id) 
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null) { throw new ResourceNotFoundException($"Author with id {id} was not found."); }
            return category;
        }
    }
}