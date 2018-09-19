namespace TechnicalRadiation.Models.DTO {
  /// <summary>
  /// A more detailed DTO for Author
  /// </summary>
  public class AuthorDetailDto : HyperMediaModel {

    /// <summary>
    /// The id of the author
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the author
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// URL to a profile image representing author
    /// </summary>
    public string ProfileImgSource { get; set; }
    /// <summary>
    /// Short bio of author (maximum of 255 charachters)
    /// </summary>
    public string Bio { get; set; }
  }
}