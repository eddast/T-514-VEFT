namespace TechnicalRadiation.Models.DTO
{
  public class CategoryDetailDto
  {

    private int Id { get; set; }
    private string Name { get; set; }
    private string Slug { get; set; }
    private int NumberOfNewsItems { get; set; }
    private int ParentCategoryId { get; set; }
  }
}