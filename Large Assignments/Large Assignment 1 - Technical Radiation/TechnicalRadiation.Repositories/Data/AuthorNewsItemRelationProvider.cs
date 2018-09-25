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
        /// <summary>
        /// Gets a list of all authors authoring news item in system
        /// </summary>
        /// <returns>List of all authors authoring news item in system</returns>
        public List<AuthorNewsItemRelation> GetAuthorNewsItemRelations() => AuthorNewsItemRelations;

        public static List<AuthorNewsItemRelation> AuthorNewsItemRelations = new List<AuthorNewsItemRelation> 
        {
            // Townsville overtaken by Mojo Jojo
            new AuthorNewsItemRelation { AuthorId = 1, NewsItemId = 1 },

            // World Overtake Fails by Ed and Mojo Jojo
            new AuthorNewsItemRelation { AuthorId = 3, NewsItemId = 2 },
            new AuthorNewsItemRelation { AuthorId = 1, NewsItemId = 2 },

            // Suspected B-and-E Turns to be Me by Johnny Bravo
            new AuthorNewsItemRelation { AuthorId = 2, NewsItemId = 3 },

            // Like, Who Are Rey's Parents? by Obi
            new AuthorNewsItemRelation { AuthorId = 4, NewsItemId = 4 },

            // Quidditch: Harder Than You'd Think! by Harry Potter
            new AuthorNewsItemRelation { AuthorId = 5, NewsItemId = 5 },

            // Glowsticks Over Broomsticks by Obi
            new AuthorNewsItemRelation { AuthorId = 4, NewsItemId = 6 },
            
            // Ron Supports Cedric by Harry Potter
            new AuthorNewsItemRelation { AuthorId = 5, NewsItemId = 7 },
        };
    }
}