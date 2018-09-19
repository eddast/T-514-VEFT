namespace TechnicalRadiation.Models.DTO {
  public class CategoryDetailDto : HyperMediaModel {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int NumberOfNewsItems { get; set; }
    public int ParentCategoryId { get; set; }
  }
}