using System;
using System.Collections.Generic;
using System.Dynamic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Models.Extensions
{
    public static class HyperMediaExtensions 
    {
        /// <summary>
        /// Adds a single relational link object for HATEOAS to link dictionary
        /// </summary>
        /// <param name="item">Link dictionary to add to</param>
        /// <param name="rel">Relation description of link</param>
        /// <param name="url">Link URL</param>
        public static void AddReference(this ExpandoObject item, string Relation, string URL) =>
          (item as IDictionary<string, object>).Add(Relation, new HypermediaLink { Href = URL });

        /// <summary>
        /// Adds to a group relational links for HATEOAS to link dictionary
        /// </summary>
        /// <param name="item">Link dictionary to add to</param>
        /// <param name="ListName">Name of relation description group for link</param>
        /// <param name="url">Link URL</param>
        public static void AddReferenceList(this ExpandoObject item, string ListName, string URL)
        {
          var links = (item as IDictionary<string, object>);
          if(!links.ContainsKey(ListName))
          {
            ICollection<HypermediaLink> NewRefList = new List<HypermediaLink>();
            links.Add(ListName, NewRefList);
          }
          List<HypermediaLink> ReferenceList = links[ListName] as List<HypermediaLink>;
          ReferenceList.Add(new HypermediaLink { Href = URL });
        }
    }
}