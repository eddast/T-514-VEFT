using System;

namespace TechnicalRadiation.Models.Entities {
  /// <summary>
  /// Category entity model
  /// </summary>
  public class Category {
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
    /// The id of the parent category
    /// </summary>
    public int ParentCategoryId { get; set; }
    /// <summary>
    /// User that modified model last
    /// </summary>
    public string ModifiedBy { get; set; }
    /// <summary>
    /// Date of creation of model
    /// </summary>
    public DateTime CreatedDate { get; set; }
    /// <summary>
    /// Date when model was modified
    /// </summary>
    public DateTime ModifiedDate { get; set; }
  }
}