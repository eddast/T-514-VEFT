using System;
using System.Collections.Generic;
using System.Dynamic;
using TechnicalRadiation.Models.DTO;

namespace TechnicalRadiation.Models.Extensions
{
    /// <summary>
    /// Enables easy creation of reference links for an expandable object dictionary
    /// (i.e. a dicitonary of keys (string) and either array of or single Hypermedia link as value)
    /// </summary>
    public static class HyperMediaExtensions 
    {
        /// <summary>
        /// Adds a single relational link object for HATEOAS to link dictionary
        /// </summary>
        /// <param name="item">Link dictionary to add to</param>
        /// <param name="rel">Relation description of link</param>
        /// <param name="url">Link URL</param>
        public static void AddReference(this IDictionary<string, object> item, string Relation, string URL) =>
          item.Add(Relation, new HypermediaLink { Href = URL });

        /// <summary>
        /// Adds to a group relational links for HATEOAS to link dictionary
        /// </summary>
        /// <param name="item">Link dictionary to add to</param>
        /// <param name="ListName">Name of relation description group for link</param>
        /// <param name="url">Link URL</param>
        public static void AddToReferenceList(this IDictionary<string, object> item, string ListName, string URL)
        {
          // Create new group of hypermedia relational links if no group exists by provided name
          if(!item.ContainsKey(ListName))
          {
            ICollection<HypermediaLink> NewReferencesList = new List<HypermediaLink>();
            item.Add(ListName, NewReferencesList);
          }
          // Add link reference to list 
          List<HypermediaLink> ReferencesList = item[ListName] as List<HypermediaLink>;
          ReferencesList.Add(new HypermediaLink { Href = URL });
        }
    }
}