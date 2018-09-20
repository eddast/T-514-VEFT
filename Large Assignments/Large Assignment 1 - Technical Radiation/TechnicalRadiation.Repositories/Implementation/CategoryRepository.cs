using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICategoryDataProvider _dataProvider;
        public CategoryRepository(ICategoryDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public IEnumerable<CategoryDto> GetAllCategories() => Mapper.Map<IEnumerable<CategoryDto>>(_dataProvider.GetCategories());

        public CategoryDetailDto GetCategoryById(int id) => Mapper.Map<CategoryDetailDto>(_dataProvider.GetCategories().FirstOrDefault(a => a.Id == id));
    }
}