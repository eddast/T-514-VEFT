using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories
{
    /// <summary>
    /// Gets category data from data provider
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        /// <summary>
        /// Data provider to use to get categories
        /// </summary>
        private readonly ICategoryDataProvider _dataProvider;

        /// <summary>
        /// Initiate data provider
        /// </summary>
        /// <param name="dataProvider">the category data provider to use</param>
        public CategoryRepository(ICategoryDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Gets all categories from data provider
        /// </summary>
        /// <returns>list of all categories</returns>
        public IEnumerable<CategoryDto> GetAllCategories() =>
            Mapper.Map<IEnumerable<CategoryDto>>(_dataProvider.GetAllCategories());

        /// <summary>
        /// Gets a single category by Id
        /// </summary>
        /// <param name="id">Id associated with category to get</param>
        /// <returns>a single category detail information by Id</returns>
        public CategoryDetailDto GetCategoryById(int id) =>
            Mapper.Map<CategoryDetailDto>(_dataProvider.GetAllCategories().FirstOrDefault(a => a.Id == id));

        /// <summary>
        /// Creates new category and adds to data
        /// </summary>
        /// <param name="newsItem">category to add to data</param>
        /// <returns>the id of the new news item</returns>
        public int CreateCategory(CategoryInputModel category)
        {
            // TODO !!
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates category by id
        /// </summary>
        /// <param name="category">new category values to set to old category</param>
        /// <param name="id">id of category to update</param>
        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            // TODO !!
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes category from system
        /// </summary>
        /// <param name="id">id of the category to delete from system</param>
        public void DeleteCategory(int id)
        {
            // TODO !!
            throw new System.NotImplementedException();
        }
    }
}