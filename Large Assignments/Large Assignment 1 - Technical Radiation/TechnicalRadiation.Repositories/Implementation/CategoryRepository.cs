using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
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
        public IEnumerable<CategoryDto> GetAllCategories() => Mapper.Map<IEnumerable<CategoryDto>>(_dataProvider.GetCategories());

        /// <summary>
        /// Gets a single category by Id
        /// </summary>
        /// <param name="id">Id associated with category to get</param>
        /// <returns>a single category detail information by Id</returns>
        public CategoryDetailDto GetCategoryById(int id) => Mapper.Map<CategoryDetailDto>(_dataProvider.GetCategories().FirstOrDefault(a => a.Id == id));
    }
}