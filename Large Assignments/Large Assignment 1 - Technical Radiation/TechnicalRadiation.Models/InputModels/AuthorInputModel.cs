using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels {
  /// <summary>
  /// Author input model
  /// </summary>
  public class AuthorInputModel {
    /// <summary>
    /// The name of the author
    /// </summary>
    /// <value>Is required</value>
    [Required]
    public string Name { get; set; }
    /// <summary>
    /// URL to profile image representing author
    /// </summary>
    /// <value>Is required and should be a legitimate URL attribute</value>
    [Required]
    [UrlAttribute]
    public string ProfileImgSource { get; set; }
    /// <summary>
    /// Bio description representing author
    /// </summary>
    /// <value>Should be of maximum length 225 characters</value>
    [MaxLength (255)]
    public string Bio { get; set; }
  }
}