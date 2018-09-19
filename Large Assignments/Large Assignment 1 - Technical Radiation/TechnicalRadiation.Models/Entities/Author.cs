using System;

namespace TechnicalRadiation.Models.Entities
{
  public class Author
  {

    private int Id { get; set; }
    private string Name { get; set; }
    private string ProfileImgSource { get; set; }
    private string Bio { get; set; }
    private string ModifiedBy { get; set; }
    private DateTime CreatedDate { get; set; }
    private DateTime ModifiedDate { get; set; }
  }
}