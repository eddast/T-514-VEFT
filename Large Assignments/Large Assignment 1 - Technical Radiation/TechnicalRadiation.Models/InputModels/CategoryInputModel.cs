using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels {
  public class CategoryInputModel {
    [Required]
    public string Name { get; set; }
    public string Slug { get; set; }
    public int ParentCategoryId { get; set; }
  }
}