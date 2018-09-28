using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
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
        /// Category to news item relations repository
        /// </summary>
        private readonly INewsItemCategoryRelationRepository _newsItemRelationRepository;

        /// <summary>
        /// Service, used to get news items for author
        /// </summary>
        private readonly INewsItemService _newsItemService;

        /// <summary>
        /// Initialize repository
        /// </summary>
        /// <param name="categoryRepository">Which implementation of category repository to use</param>
        public CategoryService(ICategoryRepository categoryRepository, INewsItemCategoryRelationRepository newsItemRelationRepository, INewsItemService newsItemService)
        {
            _categoryRepository = categoryRepository;
            _newsItemRelationRepository = newsItemRelationRepository;
            _newsItemService = newsItemService;
        }

        /// <summary>
        /// Returns list of all categories with appropriate link relations
        /// </summary>
        /// <returns>list of all categories with appropriate link relations</returns>
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
        /// <returns>single category with appropriate link relations</returns>
        public CategoryDetailDto GetCategoryById(int id) 
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null) { throw new ResourceNotFoundException($"Category with id {id} was not found."); }
            category.NumberOfNewsItems = _newsItemRelationRepository.GetAllNewsItemsCategoryRelationsByCategoryId(id).Count();
            category.AddReferences(category.Id);
            return category;
        }

        /// <summary>
        /// Creates new category and adds to system
        /// </summary>
        /// <param name="newsItem">new category to add</param>
        /// <returns>the id of new category</returns>
        public int CreateCategory(CategoryInputModel category) =>
            _categoryRepository.CreateCategory(category);

        /// <summary>
        /// Updates category by id
        /// </summary>
        /// <param name="category">new information on category to switch to</param>
        /// <param name="id">id of category to update</param>
        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var oldCategory = _categoryRepository.GetCategoryById(id);
            if (oldCategory == null) { throw new ResourceNotFoundException($"Category with id {id} was not found."); }
            _categoryRepository.UpdateCategoryById(category, id);
        }

        /// <summary>
        /// Deletes category by id
        /// </summary>
        /// <param name="id">id of category to delete</param>
        public void DeleteCategoryById(int id)
        {
            // Check if author exists, if it does delete it from list
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null) { throw new ResourceNotFoundException($"Category with id {id} was not found."); }
            _categoryRepository.DeleteCategory(id);

            // Delete all relations from list associated with category
            var newsItemRelations = _newsItemRelationRepository.GetAllNewsItemsCategoryRelationsByCategoryId(id).ToList();
            foreach(var relation in newsItemRelations) _newsItemRelationRepository.DeleteRelation(relation);
        }

        /// <summary>
        /// Links a news item to category by their ids
        /// </summary>
        /// <param name="categoryId">id of category to link to news item</param>
        /// <param name="newsItemId">id of news item to link to category</param>
        public void LinkNewsItemToCategory(int categoryId, int newsItemId)
        {
            // Check if category and news item exist by id
            GetCategoryById(categoryId);
            _newsItemService.GetNewsItemById(newsItemId);

            // if no resource not found exception is thrown, add relation if it doesn't already exist
            var newRelation = new NewsItemCategoryRelation { CategoryId = categoryId, NewsItemId = newsItemId };
            if(_newsItemRelationRepository.GetAllNewsItemsCategoryRelationsByCategoryId(categoryId).ToList().Where(x => x.CategoryId == categoryId && x.NewsItemId == newsItemId).Count() == 0){
                 _newsItemRelationRepository.AddRelation(newRelation);
            }
        }
    }
}