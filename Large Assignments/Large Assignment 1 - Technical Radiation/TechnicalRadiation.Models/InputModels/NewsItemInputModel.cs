using System;

namespace TechnicalRadiation.Models.InputModels
{
  public class NewsItemInputModel
  {
    private string Title { get; set; }
    private string ImgSource { get; set; }
    private string ShortDescription { get; set; }
    private string LongDescription { get; set; }
    private DateTime PublishDate { get; set; }
  }
}