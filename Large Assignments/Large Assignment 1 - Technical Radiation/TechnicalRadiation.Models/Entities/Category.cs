using System;

namespace TechnicalRadiation.Models.Entities
{
  public class Category
  {
    private int Id { get; set; }
    private string Name { get; set; }
    private string Slug { get; set; }
    private int ParentCategoryId { get; set; }
    private string ModifiedBy { get; set; }
    private DateTime CreatedDate { get; set; }
    private DateTime ModifiedDate { get; set; }
  }
}