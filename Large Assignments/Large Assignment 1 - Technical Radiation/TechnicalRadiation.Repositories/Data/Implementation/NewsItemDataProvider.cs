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
                PublishDate = new DateTime (DateTime.Today.Year-30, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 2,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate =  new DateTime (DateTime.Today.Year-1, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 3,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-29, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 4,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-2, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 5,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-28, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 6,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-3, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 7,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-27, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 8,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-4, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 9,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-26, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 10,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-5, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 11,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-25, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 12,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-6, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 13,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-24, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 14,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-7, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 15,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-23, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 16,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-8, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 17,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-22, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 18,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-9, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 19,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-21, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 20,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-10, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 21,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-20, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 22,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-11, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 23,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-19, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 24,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-12, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 25,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-18, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 26,
                Title = "The City of Townsville - OVERTAKEN!",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "I, Mojo Jojo, am in charge of... the city of Townsville!",
                LongDescription = "A city that is for some inexplicable reason called \"Town\" but also a \"Ville\" thus making it a city, town and village. Redundant and repetitive if you ask me, which you have no choice but to do, for now I, Mojo Jojo am in charge of the city of Townsville!",
                PublishDate = new DateTime (DateTime.Today.Year-13, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
        };
    }
}