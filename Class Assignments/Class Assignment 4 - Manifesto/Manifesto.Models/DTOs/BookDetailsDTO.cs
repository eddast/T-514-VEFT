namespace Manifesto.Models.DTOs
{
    public class BookDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
        public int Pages { get; set; }
    }
}