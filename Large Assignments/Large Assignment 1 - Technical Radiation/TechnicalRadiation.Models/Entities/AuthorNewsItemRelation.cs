using System;

namespace TechnicalRadiation.Models.Entities {
  /// <summary>
  /// Author authoring news item relation model
  /// </summary>
  public class AuthorNewsItemRelation {
    /// <summary>
    /// The id of the author authoring specified news item
    /// </summary>
    public int AuthorId { get; set; }
    /// <summary>
    /// The id of the news item authored by specified author
    /// </summary>
    public int NewsItemId { get; set; }
  }
}