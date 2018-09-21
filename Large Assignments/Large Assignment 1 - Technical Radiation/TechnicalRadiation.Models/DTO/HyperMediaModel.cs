using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace TechnicalRadiation.Models.DTO
{
  /// <summary>
  /// Represents the _links property for DTO models to honor HATEOAS
  /// _links property set as dynamically expandable dictionary object
  /// </summary>
  public class HyperMediaModel
  {
    /// <summary>
    /// Dictionary of relational HATEOAS link for hypermedia object
    /// </summary>
    /// <value></value>
    [JsonProperty (PropertyName = "_links")]
    public IDictionary<string, object> Links { get; set; }

    /// <summary>
    /// Initialize dictionary of links
    /// </summary>
    public HyperMediaModel () { Links = new Dictionary<string, object>(); }
  }
}