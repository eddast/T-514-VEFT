// This using statement is necessary to use DataAnnotations
// dotnet add package System.ComponentModel.Annotations - to add this package to the project
using System.ComponentModel.DataAnnotations;

namespace Manifesto.Models.InputModels
{
    // Intentionally missing model validation. Your job is to implement that :)
    public class BookInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
        public int Pages { get; set; }
    }
}