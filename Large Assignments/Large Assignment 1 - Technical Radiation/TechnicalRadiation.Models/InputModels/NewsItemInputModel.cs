using System;
using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels {
  /// <summary>
  /// News item input model
  /// </summary>
  public class NewsItemInputModel
  {
    /// <summary>
    /// The title of the news item
    /// </summary>
    /// <value>Is required</value>
    [Required]
    public string Title { get; set; }
    /// <summary>
    /// URL to image associated with news item
    /// </summary>
    /// <value>Is required and needs to be valid URL</value>
    [Required]
    [UrlAttribute]
    public string ImgSource { get; set; }
    /// <summary>
    /// Short description of a news item
    /// </summary>
    /// <value>Is required and is at most 50 characters</value>
    [Required]
    [MaxLength(50)]
    public string ShortDescription { get; set; }
    /// <summary>
    /// Long description of a news item
    /// </summary>
    /// <value>Is at least 50 characters and at most 255 characters</value>
    [MinLength(50)]
    [MaxLength(255)]
    public string LongDescription { get; set; }
    /// <summary>
    /// Date when news item is publised
    /// </summary>
    /// <value>Is required</value>
    [Required]
    public DateTime? PublishDate { get; set; }
  }
}