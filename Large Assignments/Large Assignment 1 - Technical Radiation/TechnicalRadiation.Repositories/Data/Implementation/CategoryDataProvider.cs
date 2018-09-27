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
        /// <summary>
        /// Gets a list of all category in system
        /// </summary>
        /// <returns>List of all category in system</returns>
        public List<Category> GetAllCategories() => Categories;

        /// <summary>
        /// Admin that authors modification of category
        /// </summary>
        private static readonly string _adminName = "SystemAdmin";

        /// <summary>
        /// List of all categories in system
        /// </summary>
        /// <returns>category entity model list</returns>
        private static List<Category> Categories = new List<Category> 
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
                Name = "Politics",
                Slug = "politics",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 3,
                Name = "Evil Overlord Politics",
                Slug = "evil-overlord-politics",
                ParentCategoryId = 2,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 4,
                Name = "Science",
                Slug = "science",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 5,
                Name = "Health Science",
                Slug = "health-science",
                ParentCategoryId = 4,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 6,
                Name = "Sports",
                Slug = "sports",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 7,
                Name = "News",
                Slug = "news",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}