namespace TechnicalRadiation.Models.InputModels
{
  public class CategoryInputModel
  {
    private string Name { get; set; }
    private string Slug { get; set; }
    private int ParentCategoryId { get; set; }
  }
}