// This using statement is necessary to use DataAnnotations
// dotnet add package System.ComponentModel.Annotations - to add this package to the project
using System.ComponentModel.DataAnnotations;

namespace Manifesto.Models.InputModels
{
    public class BookInputModel
    {
        [Required(ErrorMessage = "Book name is required")]
        [MinLength(3, ErrorMessage = "Book Name is at least three letters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Book author is required")]
        public string Author { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Book image URL is required")]
        public string ImageUrl { get; set; }

        public string Isbn { get; set; }

        [RegularExpression("Games|Software Development|Romance|Self-help|Uncategorized", ErrorMessage = "Invalid category")]
        public string Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Book must have one or more pages")]
        public int? Pages { get; set; }
    }
}