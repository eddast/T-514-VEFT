using System;

namespace TechnicalRadiation.Models.DTO
{
  public class NewsItemDetailDto
  {
    private int Id { get; set; }
    private string Title { get; set; }
    private string ImgSource { get; set; }
    private string ShortDescription { get; set; }
    private string LongDescription { get; set; }
    private DateTime PublishDate { get; set; }
  }
}