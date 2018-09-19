using System;

namespace TechnicalRadiation.Models.Entities {
  /// <summary>
  /// Author entity model
  /// </summary>
  public class Author {
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
    /// <summary>
    /// User that modified model last
    /// </summary>
    public string ModifiedBy { get; set; }
    /// <summary>
    /// Date of creation of model
    /// </summary>
    public DateTime CreatedDate { get; set; }
    /// <summary>
    /// Date when model was modified
    /// </summary>
    public DateTime ModifiedDate { get; set; }
  }
}