using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;

namespace TechnicalRadiation.Repositories.Data
{
    /// <summary>
    /// Serves data of authors authoring news items from source in system
    /// </summary>
    public class AuthorNewsItemRelationProvider : IAuthorNewsItemRelationsProvider
    {
        public List<AuthorNewsItemRelation> GetsAuthorNewsItemRelations() => AuthorNewsItemRelations;
        private static readonly string _adminName = "SystemAdmin";

        /// <summary>
        /// Gets a list of all authors authoring news item in system
        /// </summary>
        /// <returns>List of all authors authoring news item in system</returns>
        public static List<AuthorNewsItemRelation> AuthorNewsItemRelations = new List<AuthorNewsItemRelation> 
        {
            new AuthorNewsItemRelation
            {
                AuthorId = 1,
                NewsItemId = 1
            },
            new AuthorNewsItemRelation
            {
                AuthorId = 3,
                NewsItemId = 2
            },
            new AuthorNewsItemRelation
            {
                AuthorId = 2,
                NewsItemId = 3
            },
            new AuthorNewsItemRelation
            {
                AuthorId = 4,
                NewsItemId = 4
            },
            new AuthorNewsItemRelation
            {
                AuthorId = 5,
                NewsItemId = 5
            },
            new AuthorNewsItemRelation
            {
                AuthorId = 4,
                NewsItemId = 6
            },
            new AuthorNewsItemRelation
            {
                AuthorId = 5,
                NewsItemId = 7
            },
        };
    }
}