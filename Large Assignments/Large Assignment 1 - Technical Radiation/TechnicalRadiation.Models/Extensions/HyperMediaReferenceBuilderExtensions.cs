using System;
using System.Collections.Generic;
using System.Dynamic;
using TechnicalRadiation.Common;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using System.Linq;

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
        /// <param name="Id">Id of author news item to add reference to</param>
        public static void AddReferences(this NewsItemDto item, int Id, IEnumerable<NewsItemCategoryRelation> categoryRelations, IEnumerable<AuthorNewsItemRelation> authorRelations)
        {
            item.AddNewsItemReferences(Id, categoryRelations, authorRelations);
        }
        public static void AddReferences(this NewsItemDetailDto item, int Id, IEnumerable<NewsItemCategoryRelation> categoryRelations, IEnumerable<AuthorNewsItemRelation> authorRelations)
        {
            item.AddNewsItemReferences(Id, categoryRelations, authorRelations);
        }


        /// <summary>
        /// Adds correct HATEOAS link references to Author hypermedia model
        /// </summary>
        /// <param name="HyperMediaModel">Hypermedia model of type Author to add references to</param>
        /// <param name="Id">Id of author resource to add reference to</param>
        public static void AddReferences(this AuthorDto item, int Id, IEnumerable<AuthorNewsItemRelation> newsItems) { item.AddAuthorReferences(Id, newsItems); }
        public static void AddReferences(this AuthorDetailDto item, int Id, IEnumerable<AuthorNewsItemRelation> newsItems) { item.AddAuthorReferences(Id, newsItems); }

        /// <summary>
        /// Adds correct HATEOAS link references to Category hypermedia model
        /// </summary>
        /// <param name="HyperMediaModel">Hypermedia model of type Category to add references to</param>
        /// <param name="Id">Id of category resource to add reference to</param>
        public static void AddReferences(this CategoryDto item, int Id) { item.AddCategoryReferences(Id); }
        public static void AddReferences(this CategoryDetailDto item, int Id) { item.AddCategoryReferences(Id); }

        /// <summary>
        /// Adds self, edit and delete links for resources
        /// (All these actions are supported for all types of DTOs in system)
        /// </summary>
        /// <param name="HyperMediaModel">Hypermedia model to add reference to self, edit and delete</param>
        /// <param name="Id">Id of resource to add reference to</param>
        private static void AddBaseReferences(this HyperMediaModel HyperMediaModel, int Id, string ResourseBaseRoute)
        {
            string RouteToResource = ResourseBaseRoute + "/" + Id.ToString() ;
            HyperMediaModel.Links.AddReference("self", RouteToResource);
            HyperMediaModel.Links.AddReference("edit", RouteToResource);
            HyperMediaModel.Links.AddReference("delete", RouteToResource);
        }

        /// <summary>
        /// Adds references specific to news items
        /// </summary>
        /// <param name="HyperMediaModel">news item dto or news item details dto to add references to</param>
        /// <param name="Id">Id of news item resource to add reference to</param>
        private static void AddNewsItemReferences (this HyperMediaModel HyperMediaModel, int Id, IEnumerable<NewsItemCategoryRelation> categoryRelations, IEnumerable<AuthorNewsItemRelation> authorRelations)
        {
            // routes needed for links
            string newsItemRoute = Routes.BASE + Routes.NEWS_ITEM;
            string authorRoute = Routes.BASE + Routes.AUTHORS;
            string categoriesRoute = Routes.BASE + Routes.CATEGORIES;

            // add get, edit and update links for actions on this resource
            HyperMediaModel.AddBaseReferences(Id, newsItemRoute);
        
            // For each category associated with resouce, add link for getting detail info on it
            Func<int, string> linkCategoryDetailByNewsItem = categoryId => categoriesRoute + "/" + categoryId;
            foreach(var item in categoryRelations) HyperMediaModel.Links.AddToReferenceList("categories", linkCategoryDetailByNewsItem(item.CategoryId));
            
            // For each author associated with resouce, add link for getting detail info on it
            Func<int, string> linkAuthorByNewsItem = authorId => authorRoute + "/" + authorId;
            foreach(var item in authorRelations) HyperMediaModel.Links.AddToReferenceList("authors", linkAuthorByNewsItem(item.AuthorId));
        }

        /// <summary>
        /// Adds references to authors resources
        /// Needs list on author news item relations so that news items for authors are correctly referenced
        /// </summary>
        /// <param name="HyperMediaModel">author dto or author details dto to add references to</param>
        /// <param name="Id">Id of author resource to add reference to</param>
        /// <param name="newsItems">All news items associated with author</param>
        private static void AddAuthorReferences (this HyperMediaModel HyperMediaModel, int Id, IEnumerable<AuthorNewsItemRelation> newsItems)
        {
            // routes needed for links
            string newsItemRoute = Routes.BASE + Routes.NEWS_ITEM;
            string authorRoute = Routes.BASE + Routes.AUTHORS;

            // add get, edit and update links for actions on this resource
            HyperMediaModel.AddBaseReferences(Id, Routes.AUTHORS);

            // add links to get list of all authored items for this resource
            string linkToAllAuthoredNewsItems = authorRoute + "/" + Id + "/newsItems";
            HyperMediaModel.Links.AddReference("newsItems", linkToAllAuthoredNewsItems);

            // add links to get a detail info of news item related to this resource
            Func<int, string> linkNewsItemDetailByAuthor = newsItemId => newsItemRoute + "/" + newsItemId;
            foreach(var item in newsItems) HyperMediaModel.Links.AddToReferenceList("newsItemsDetailed", linkNewsItemDetailByAuthor(item.NewsItemId));
        }

        /// <summary>
        /// Adds appropriate references to categories resources
        /// </summary>
        /// <param name="HyperMediaModel">category dto or category details dto to add references to</param>
        /// <param name="Id">Id of category resource to add reference to</param>
        private static void AddCategoryReferences (this HyperMediaModel HyperMediaModel, int Id)
        {
            // routes needed for links
            string categoriesRoute = Routes.BASE + Routes.CATEGORIES;

            // add get, edit and update links for actions on this resource
            HyperMediaModel.AddBaseReferences(Id, categoriesRoute);
        }
    }
}