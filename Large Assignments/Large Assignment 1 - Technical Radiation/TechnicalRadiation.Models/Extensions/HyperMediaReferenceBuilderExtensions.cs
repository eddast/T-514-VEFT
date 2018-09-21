using System;
using System.Collections.Generic;
using System.Dynamic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Models.Extensions
{
    /// <summary>
    /// Adds appropriate references to DTO models
    /// </summary>
    public static class HyperMediaReferenceBuilderExtensions 
    {
        /// <summary>
        /// Adds correct HATEOAS link references to News Item hypermedia model
        /// </summary>
        /// <param name="HyperMediaModel">Hypermedia model of type News Item to add references to</param>
        public static void AddReferences(this NewsItemDto item) { item.AddNewsItemReferences(); }
        public static void AddReferences(this NewsItemDetailDto item) { item.AddNewsItemReferences(); }


        /// <summary>
        /// Adds correct HATEOAS link references to Author hypermedia model
        /// </summary>
        /// <param name="HyperMediaModel">Hypermedia model of type Author to add references to</param>
        public static void AddReferences(this AuthorDto item) { item.AddAuthorReferences(); }
        public static void AddReferences(this AuthorDetailDto item) { item.AddAuthorReferences(); }

        /// <summary>
        /// Adds correct HATEOAS link references to Category hypermedia model
        /// </summary>
        /// <param name="HyperMediaModel">Hypermedia model of type Category to add references to</param>
        public static void AddReferences(this CategoryDto item) { item.AddCategoryReferences(); }
        public static void AddReferences(this CategoryDetailDto item) { item.AddCategoryReferences(); }

        /// <summary>
        /// Adds self, edit and delete links for resources
        /// (All these actions are supported for all types of DTOs in system)
        /// </summary>
        /// <param name="HyperMediaModel">Hypermedia model to add reference to self, edit and delete</param>
        private static void AddBaseReferences(this HyperMediaModel HyperMediaModel)
        {
            HyperMediaModel.Links.AddReference("self", "...");
            HyperMediaModel.Links.AddReference("edit", "...");
            HyperMediaModel.Links.AddReference("delete", "...");
        }

        /// <summary>
        /// Adds references specific to news items
        /// </summary>
        /// <param name="HyperMediaModel">news item dto or news item details dto to add references to</param>
        private static void AddNewsItemReferences (this HyperMediaModel HyperMediaModel)
        {
            HyperMediaModel.AddBaseReferences();
            HyperMediaModel.Links.AddToReferenceList("categories", "<categorylink1>");
            HyperMediaModel.Links.AddToReferenceList("categories", "<categorylink2>");
            HyperMediaModel.Links.AddToReferenceList("authors", "<authorlink1>");
            HyperMediaModel.Links.AddToReferenceList("authors", "<authorlink2>");
        }

        /// <summary>
        /// Adds references specific to authors
        /// </summary>
        /// <param name="HyperMediaModel">author dto or author details dto to add references to</param>
        private static void AddAuthorReferences (this HyperMediaModel HyperMediaModel)
        {
            HyperMediaModel.AddBaseReferences();
            HyperMediaModel.Links.AddReference("newsItems", "<linkToAuthorNewsItems>");
            HyperMediaModel.Links.AddToReferenceList("newsItemsDetails", "<newsItemLink1>");
            HyperMediaModel.Links.AddToReferenceList("newsItemsDetails", "<newsItemLink2>");
        }

        /// <summary>
        /// Adds references specific to categories
        /// </summary>
        /// <param name="HyperMediaModel">category dto or category details dto to add references to</param>
        private static void AddCategoryReferences (this HyperMediaModel HyperMediaModel)
        {
            HyperMediaModel.AddBaseReferences();
        }
    }
}