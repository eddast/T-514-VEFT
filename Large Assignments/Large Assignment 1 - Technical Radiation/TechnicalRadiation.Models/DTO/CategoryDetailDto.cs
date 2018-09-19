namespace TechnicalRadiation.Models.DTO {
  /// <summary>
  /// A more detailed DTO for Category
  /// </summary>
  public class CategoryDetailDto : HyperMediaModel {

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
    /// <summary>
    /// Number of news items associated with category
    /// </summary>
    public int NumberOfNewsItems { get; set; }
    /// <summary>
    /// The id of the parent category
    /// </summary>
    public int ParentCategoryId { get; set; }
  }
}