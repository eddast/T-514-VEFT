using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data.Interfaces
{
    public interface ICategoryDataProvider
    {
         List<Category> GetCategories();
    }
}