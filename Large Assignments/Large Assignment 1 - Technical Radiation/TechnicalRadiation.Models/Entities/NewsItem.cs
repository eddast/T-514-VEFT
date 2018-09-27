using System;

namespace TechnicalRadiation.Models.Entities {

  /// <summary>
  /// News item entity model
  /// </summary>
  public class NewsItem {
    /// <summary>
    /// The id of the news item
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// News item title
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Image URL associated with news item
    /// </summary>
    public string ImgSource { get; set; }
    /// <summary>
    /// Short description of news item
    /// </summary>
    public string ShortDescription { get; set; }
    /// <summary>
    /// Long description of news item
    /// </summary>
    public string LongDescription { get; set; }
    /// <summary>
    /// News item publish date
    /// </summary>
    public DateTime PublishDate { get; set; }
    /// <summary>
    /// Name of person that modified news item last
    /// </summary>
    public string ModifiedBy { get; set; }
    /// <summary>
    /// Date of news item creation
    /// </summary>
    public DateTime CreatedDate { get; set; }
    /// <summary>
    /// Date when news item was last modified
    /// </summary>
    public DateTime ModifiedDate { get; set; }
  }
}