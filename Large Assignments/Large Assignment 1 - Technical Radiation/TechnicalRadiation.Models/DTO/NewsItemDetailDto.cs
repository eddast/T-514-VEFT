using System;

namespace TechnicalRadiation.Models.DTO {
  public class NewsItemDetailDto : HyperMediaModel {
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImgSource { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public DateTime PublishDate { get; set; }
  }
}