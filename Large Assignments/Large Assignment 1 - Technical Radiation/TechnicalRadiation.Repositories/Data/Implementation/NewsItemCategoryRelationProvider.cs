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
            new NewsItemCategoryRelation
            {
                NewsItemId = 1,
                CategoryId = 3
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 2,
                CategoryId = 3
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 3,
                CategoryId = 7
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 3,
                CategoryId = 1
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 4,
                CategoryId = 1
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 5,
                CategoryId = 4
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 5,
                CategoryId = 5
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 5,
                CategoryId = 6
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 6,
                CategoryId = 6
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 6,
                CategoryId = 2
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 7,
                CategoryId = 1
            },
            new NewsItemCategoryRelation
            {
                NewsItemId = 7,
                CategoryId = 2
            },
        };
    }
}