using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data.Interfaces
{
    public interface IAuthorDataProvider
    {
        /// <summary>
        /// Gets a list of all authors in system
        /// </summary>
        /// <returns>List of all authors in system</returns>
         List<Author> GetAuthors();
    }
}