using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data.Interfaces
{
    /// <summary>
    /// Serves data from source in system
    /// </summary>
    public interface IAuthorNewsItemRelationsProvider
    {
        /// <summary>
        /// Gets a list of all relations representing authors authoring news item in system
        /// </summary>
        /// <returns>List of all relations representing authors authoring news item in system</returns>
        List<AuthorNewsItemRelation> GetAuthorNewsItemRelations();
    }
}