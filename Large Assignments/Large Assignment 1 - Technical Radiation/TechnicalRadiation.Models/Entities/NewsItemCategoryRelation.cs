using System;

namespace TechnicalRadiation.Models.Entities {
  /// <summary>
  /// News item belonging to category relation model
  /// </summary>
  public class NewsItemCategoryRelation {
    /// <summary>
    /// The id of the news item belonging to specified category
    /// </summary>
    public int NewsItemId { get; set; }
    /// <summary>
    /// The id of the category specified news item belongs to
    /// </summary>
    public int CategoryId { get; set; }
  }
}