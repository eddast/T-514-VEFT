namespace TechnicalRadiation.Models.DTO {
  /// <summary>
  /// Minimal DTO for Author
  /// </summary>
  public class AuthorDto : HyperMediaModel {
    /// <summary>
    /// The id of the author
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the author
    /// </summary>
    public string Name { get; set; }
  }
}