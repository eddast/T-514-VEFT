using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDetailDto GetCategoryById(int id);
        
    }
}