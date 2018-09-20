using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;

namespace TechnicalRadiation.Repositories.Data
{
    public class CategoryDataProvider : ICategoryDataProvider
    {
        public List<Category> GetCategories() => Categories;
        private static readonly string _adminName = "CategoryAdmin";
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
            }
        };
    }
}