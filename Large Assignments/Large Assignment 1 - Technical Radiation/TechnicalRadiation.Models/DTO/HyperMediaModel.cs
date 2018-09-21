using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace TechnicalRadiation.Models.DTO {
  public class HyperMediaModel
  {
    /// <summary>
    /// Dictionary of relational HATEOAS link for hypermedia object
    /// </summary>
    /// <value></value>
    [JsonProperty (PropertyName = "_links")]
    public ExpandoObject Links { get; set; }

    /// <summary>
    /// Initialize dictionary of links
    /// </summary>
    public HyperMediaModel () { Links = new ExpandoObject(); }

  }
}