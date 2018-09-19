namespace TechnicalRadiation.Models.DTO {
  /// <summary>
  /// Minimal DTO for Category
  /// </summary>
  public class CategoryDto : HyperMediaModel {
    /// <summary>
    /// The id of the category
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the category
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The name of the category in lowercase with hyphen instead of spaces
    /// </summary>
    public string Slug { get; set; }
  }
}