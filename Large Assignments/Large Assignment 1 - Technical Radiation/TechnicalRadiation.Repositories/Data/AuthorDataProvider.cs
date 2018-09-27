using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;

namespace TechnicalRadiation.Repositories.Data
{
    /// <summary>
    /// Serves data from source in system
    /// </summary>
    public class AuthorDataProvider: IAuthorDataProvider
    {

        /// <summary>
        /// Gets a list of all authors in system
        /// </summary>
        /// <returns>List of all authors in system</returns>
        public List<Author> GetAllAuthors() => Authors;

        /// <summary>
        /// Admin that authors modification of news items
        /// </summary>
        private static readonly string _adminName = "SystemAdmin";

        /// <summary>
        /// list of all authors in system
        /// </summary>
        /// <value>author entity model list</value>
        private static List<Author> Authors = new List<Author> 
        {
            new Author
            {
                Id = 1,
                Name = "Mojo Jojo",
                ProfileImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/c/c9/Mojo_jojo_aparincia2.png/revision/latest?cb=20160612021838",
                Bio = "He is not Bubbles! Bubbles is not his name! For the name Bubbles is not the correct name to address him by! If you were to address him by the name Mojo Jojo, that would be correct, for his name is Mojo Jojo!",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 2,
                Name = "Johnny Bravo",
                ProfileImgSource = "https://ih0.redbubble.net/image.286736359.2796/flat,550x550,075,f.jpg",
                Bio = "Hey, Baby! Anybody ever tell you I have beautiful eyes? Enough about you, let's talk about me, Johnny Bravo. Now remember, I do my best work when I'm being worshiped as a god.",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 3,
                Name = "Ed",
                ProfileImgSource = "https://pre00.deviantart.net/20bb/th/pre/f/2017/260/d/5/ed__edd_n_eddy___ed__2_by_ali_srn-dbnp4ax.png",
                Bio = "Smells like fresh cut flowers sputing over a babling brook with a hint of lemon",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 4,
                Name = "Obi Wan Kenobi",
                ProfileImgSource = "https://starwarsblog.starwars.com/wp-content/uploads/sites/6/2017/08/star-wars-episode-3-obi-wan-mustafar.jpg",
                Bio = "He has the high ground, Anakin.",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 5,
                Name = "Harry Potter",
                ProfileImgSource = "https://timedotcom.files.wordpress.com/2014/07/301386_full1.jpg",
                Bio = "THE BOY WHO LIVED! Likes to spend inherited money on candy and looking at girls in showers with an invisibility cloak.",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
        };
    }
}