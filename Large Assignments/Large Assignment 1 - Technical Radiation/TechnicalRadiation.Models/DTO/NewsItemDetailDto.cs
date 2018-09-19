using System;

namespace TechnicalRadiation.Models.DTO {
  /// <summary>
  /// A more detailed DTO for News Item
  /// </summary>
  public class NewsItemDetailDto {
    /// <summary>
    /// The id of the news item
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The title of the news item
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// URL to the source image associated with news item
    /// </summary>
    public string ImgSource { get; set; }
    /// <summary>
    /// Short description (50 character maximum) of news item
    /// </summary>
    public string ShortDescription { get; set; }
    /// <summary>
    /// Long description (50 character minimum, 255 maximum) of news item
    /// </summary>
    public string LongDescription { get; set; }
    /// <summary>
    /// Date of publish for news item
    /// </summary>
    public DateTime PublishDate { get; set; }
  }
}