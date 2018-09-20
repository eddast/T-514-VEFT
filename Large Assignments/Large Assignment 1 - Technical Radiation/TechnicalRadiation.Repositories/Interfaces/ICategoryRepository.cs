using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDetailDto GetCategoryById(int id);
        
    }
}