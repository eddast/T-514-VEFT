using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public class AuthorDataProvider
    {
        private static readonly string _adminName = "CategoryAdmin";
        public static List<Author> Categories = new List<Author> 
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
            }
        };
    }
}