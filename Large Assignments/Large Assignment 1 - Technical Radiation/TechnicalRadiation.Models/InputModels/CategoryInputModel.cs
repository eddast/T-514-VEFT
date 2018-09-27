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
    [MaxLength(60)]
    public string Name { get; set; }
    /// <summary>
    /// Id of category's parent category
    /// </summary>
    public int? ParentCategoryId { get; set; }
  }
}