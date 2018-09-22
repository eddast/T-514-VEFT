namespace TechnicalRadiation.Models.DTO {
  public class NewsItemDto : HyperMediaModel
  {
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
  }
}