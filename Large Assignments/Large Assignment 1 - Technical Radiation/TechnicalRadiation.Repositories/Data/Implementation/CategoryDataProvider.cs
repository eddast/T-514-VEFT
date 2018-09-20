using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;

namespace TechnicalRadiation.Repositories.Data
{
    /// <summary>
    /// Serves data from source in system
    /// </summary>
    public class CategoryDataProvider : ICategoryDataProvider
    {
        public List<Category> GetCategories() => Categories;
        private static readonly string _adminName = "SystemAdmin";

        /// <summary>
        /// Returns a list of all categories in system
        /// </summary>
        /// <returns>List of all categories in system</returns>
        public static List<Category> Categories = new List<Category> 
        {
            new Category
            {
                Id = 1,
                Name = "Gossip",
                Slug = "gossip",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 2,
                Name = "The Hottest Gossip",
                Slug = "the-hottest-gossip",
                ParentCategoryId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 3,
                Name = "Politics",
                Slug = "politics",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 4,
                Name = "Evil Overlord Politics",
                Slug = "evil-overlord-politics",
                ParentCategoryId = 3,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 5,
                Name = "Science",
                Slug = "science",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 7,
                Name = "Health Science",
                Slug = "health-science",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 8,
                Name = "Sports",
                Slug = "sports",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}