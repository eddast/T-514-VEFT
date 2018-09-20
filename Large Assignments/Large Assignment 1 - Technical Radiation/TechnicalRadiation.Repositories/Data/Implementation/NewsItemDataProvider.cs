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
                Title = "Townsville Overtaken!",
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
                Title = "World Overtake Fails",
                ImgSource = "https://i.pinimg.com/736x/2c/26/b5/2c26b51f42e195a85487e1b524bccfa0--s-cartoons-cartoons-love.jpg",
                ShortDescription = "Pinky and the Brain: They've Failed Once Again",
                LongDescription = "They're Pinky and the Brain - Yes, Pinky and the Brain. One is a genius, the other's insane. They're laboratory mice, their genes have been spliced. They're Pinky, they're Pinky and the Brain brain brain brain, brain brain brain brain.",
                PublishDate =  new DateTime (DateTime.Today.Year-1, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 3,
                Title = "Suspected B-and-E Turns to be Me",
                ImgSource = "https://i.ytimg.com/vi/xqtNv6i0dlk/hqdefault.jpg",
                ShortDescription = "Man, I'm pretty.",
                LongDescription = "I looked in the mirror and thought, 'Wait, who's that handsome guy?' and called 911 and said: 'Hello, 911 emergency? There's a handsome guy in my house! Oh, wait, cancel that. It's only me.'",
                PublishDate = new DateTime (DateTime.Today.Year-29, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 4,
                Title = "Like, Who Are Rey's Parents?",
                ImgSource = "https://upload.wikimedia.org/wikipedia/en/thumb/a/af/Rey_Star_Wars.png/220px-Rey_Star_Wars.png",
                ShortDescription = "Seriously, Did I Father Her?",
                LongDescription = "There's been rumors going about that Rey might be my daughter. Could she be? I think it's far fetched - but it's plausible!",
                PublishDate = new DateTime (DateTime.Today.Year-2, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 5,
                Title = "Quidditch: Harder Than You'd Think!",
                ImgSource = "https://vignette.wikia.nocookie.net/harrypotter/images/8/89/Quidditch_Pitch.JPG/revision/latest?cb=20070114195447",
                ShortDescription = "Quidditch: Harder Sport Than Lightsaber Fighting",
                LongDescription = "According to recent research papers, Quidditch is more beneficial to your health than lightsaber sword fights. It burns more calories all the while building more muscles. PLUS IT'S SO MUCH FUN!",
                PublishDate = new DateTime (DateTime.Today.Year-28, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 6,
                Title = "Glowsticks Over Broomsticks",
                ImgSource = "https://vignette.wikia.nocookie.net/starwars/images/6/61/Crossguard_lightsaber.png/revision/latest?cb=20160414004941",
                ShortDescription = "Quidditch Does not Compare to Lightsaber Fighting",
                LongDescription = "How can people even think that Quidditch has health benefits over light saber fighting? Like seriously - ALL YOU DO IS SIT ON A STICK. We're jumping, doing somersaults and well.. the occasional death is just a you gotta price to pay for COOLNESS!",
                PublishDate = new DateTime (DateTime.Today.Year-3, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new NewsItem
            {
                Id = 7,
                Title = "Ron Supports Cedric",
                ImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/a/a7/City_of_townsville_night_2016.png/revision/latest?cb=20160609100038",
                ShortDescription = "Ron Suspected of Supporting Cedric over Best Pal",
                LongDescription = "Ron seems to have had a fall out with best friend Harry and now supports Cedric, Hufflepuff's most SPARKLING student, in the Triwizard Cup. Questioned on the matter, Harry 'wishes he had a fuck to give, but he gave his last to Ginny'.",
                PublishDate = new DateTime (DateTime.Today.Year-27, DateTime.Today.Month, DateTime.Today.Day),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}