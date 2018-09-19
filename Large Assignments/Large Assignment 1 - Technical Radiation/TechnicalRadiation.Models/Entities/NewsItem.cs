using System;

namespace TechnicalRadiation.Models.Entities
{
  public class NewsItem
  {
    private int Id { get; set; }
    private string Title { get; set; }
    private string ImgSource { get; set; }
    private string ShortDescription { get; set; }
    private string LongDescription { get; set; }
    private DateTime PublishDate { get; set; }
    private string ModifiedBy { get; set; }
    private DateTime CreatedDate { get; set; }
    private DateTime ModifiedDate { get; set; }
  }
}