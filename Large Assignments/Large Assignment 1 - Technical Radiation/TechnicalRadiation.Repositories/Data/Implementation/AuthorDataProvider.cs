using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data.Interfaces;

namespace TechnicalRadiation.Repositories.Data
{
    public class AuthorDataProvider : IAuthorDataProvider
    {
        public List<Author> GetAuthors() => Authors;
        private static readonly string _adminName = "CategoryAdmin";
        public static List<Author> Authors = new List<Author> 
        {
            new Author
            {
                Id = 1,
                Name = "Mojo Jojo",
                ProfileImgSource = "https://vignette.wikia.nocookie.net/powerpuff/images/c/c9/Mojo_jojo_aparincia2.png/revision/latest?cb=20160612021838",
                Bio = "I am not Bubbles! Bubbles is not my name! For the name Bubbles is not the correct name to address me by, because is not my name! If you were to address me by the name Mojo Jojo, that would be correct, for my name is Mojo Jojo!",
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
                Bio = "I smell like fresh cut flowers sputing over a babling brook with a hint of lemon",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 4,
                Name = "Obi Wan Kenobi",
                ProfileImgSource = "https://starwarsblog.starwars.com/wp-content/uploads/sites/6/2017/08/star-wars-episode-3-obi-wan-mustafar.jpg",
                Bio = "I have the high ground.",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 5,
                Name = "Anakin Skywalker",
                ProfileImgSource = "https://vignette.wikia.nocookie.net/starwars/images/6/6f/Anakin_Skywalker_RotS.png/revision/latest?cb=20130621175844",
                Bio = "I don't like sand. It's coarse and rough and irritating and it gets everywhere. Not like here. Here everything is soft and smooth.",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _adminName
            },
        };
    }
}