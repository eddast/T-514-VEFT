using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;

namespace TechnicalRadiation.Repositories.Data
{
    /// <summary>
    /// Serves data of news items belonging to one or more categories from source in system
    /// </summary>
    public class NewsItemCategoryRelationProvider : INewsItemCategoryRelationProvider
    {
        /// <summary>
        /// Gets a list of all news items belonging to one or more categories in system
        /// </summary>
        /// <returns>List of all news items belonging to one or more categories in system</returns>
        public List<NewsItemCategoryRelation> GetNewsItemCategoryRelations() => NewsItemCategoryRelations;

        public static List<NewsItemCategoryRelation> NewsItemCategoryRelations = new List<NewsItemCategoryRelation> 
        {
            // Townsville overtaken belongs to evil overtakes and news categories
            new NewsItemCategoryRelation { NewsItemId = 1, CategoryId = 3 },
            new NewsItemCategoryRelation { NewsItemId = 1, CategoryId = 7 },

            // World Overtake Fails belongs to evil overtakes category
            new NewsItemCategoryRelation { NewsItemId = 2, CategoryId = 3 },

            // Suspected B-and-E Turns to be Me belongs to gossip and news categories
            new NewsItemCategoryRelation { NewsItemId = 3, CategoryId = 1 },
            new NewsItemCategoryRelation { NewsItemId = 3, CategoryId = 7 },

            // Like, Who Are Rey's Parents? belongs to gossip category
            new NewsItemCategoryRelation { NewsItemId = 4, CategoryId = 1 },

            // Quidditch: Harder Than You'd Think! belongs to science, health science and sports categories
            new NewsItemCategoryRelation { NewsItemId = 5, CategoryId = 4 },
            new NewsItemCategoryRelation { NewsItemId = 5, CategoryId = 5 },
            new NewsItemCategoryRelation { NewsItemId = 5, CategoryId = 6 },

            // Glowsticks Over Broomsticks belongs to sports and politics categories
            new NewsItemCategoryRelation { NewsItemId = 6, CategoryId = 2 },
            new NewsItemCategoryRelation { NewsItemId = 6, CategoryId = 6 },

            // Ron Supports Cedric belongs to gossip and politics categories
            new NewsItemCategoryRelation { NewsItemId = 7, CategoryId = 1 },
            new NewsItemCategoryRelation { NewsItemId = 7, CategoryId = 2 },
        };
    }
}