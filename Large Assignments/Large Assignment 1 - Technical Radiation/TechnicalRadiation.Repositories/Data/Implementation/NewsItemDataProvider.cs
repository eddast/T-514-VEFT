using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;

namespace TechnicalRadiation.Repositories.Data
{
    /// <summary>
    /// Serves data from source in system
    /// </summary>
    public class NewsItemDataProvider : INewsItemDataProvider
    {
        public List<NewsItem> GetNewsItems() => NewsItems;
        private static readonly string _adminName = "SystemAdmin";

        /// <summary>
        /// Returns list of all news items in system
        /// </summary>
        /// <returns>list of all news items in system</returns>
        private static List<NewsItem> NewsItems = new List<NewsItem> 
        {
            new NewsItem
            {
                Id = 1,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}