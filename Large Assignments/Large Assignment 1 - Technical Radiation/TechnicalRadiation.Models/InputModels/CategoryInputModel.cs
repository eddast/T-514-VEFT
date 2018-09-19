using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels {
  /// <summary>
  /// Category input model
  /// </summary>
  public class CategoryInputModel {
    /// <summary>
    /// The name of the category
    /// </summary>
    /// <value>Is required</value>
    [Required]
    public string Name { get; set; }
    /// <summary>
    /// Name of category in lowercase with a hyphen instead of spaces
    /// </summary>
    public string Slug { get; set; }
    /// <summary>
    /// Id of category's parent category
    /// </summary>
    public int ParentCategoryId { get; set; }
  }
}