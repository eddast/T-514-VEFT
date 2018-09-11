using System;

namespace Manifesto.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
        public int Pages { get; set; }
        
        #region Metadata
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
    }
}