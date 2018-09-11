// This using statement is necessary to use DataAnnotations
// dotnet add package System.ComponentModel.Annotations - to add this package to the project
using System.ComponentModel.DataAnnotations;

namespace Manifesto.Models.InputModels
{
    // Intentionally missing model validation. Your job is to implement that :)
    public class BookInputModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
        public int Pages { get; set; }
    }
}