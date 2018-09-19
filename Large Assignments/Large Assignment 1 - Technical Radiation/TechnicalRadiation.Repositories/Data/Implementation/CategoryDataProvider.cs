using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public class CategoryDataProvider
    {
        private static readonly string _adminName = "CategoryAdmin";
        public static List<Category> Categories = new List<Category> 
        {
            new Category
            {
                Id = 1,
                Name = "The Hottest Gossip",
                Slug = "the-hottest-gossip",
                ParentCategoryId = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}