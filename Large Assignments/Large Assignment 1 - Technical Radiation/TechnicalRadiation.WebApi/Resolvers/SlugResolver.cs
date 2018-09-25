using AutoMapper;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.WebApi.Resolvers
{
    /// <summary>
    /// Generates the slug field when automapping catagory input model to category entities
    /// Transforms the 'Name' field from input model to lower-case and replaces the spacing with a hyphen '-'
    /// </summary>
    public class SlugResolver : IValueResolver<CategoryInputModel, Category, string>
    {
        /// <summary>
        /// Generates the slug field when mapping catagory input model to category entities
        /// Transforms the 'Name' field from input model to lower-case and replaces the spacing with a hyphen '-'
        /// </summary>
        /// <param name="source">Category input model including the field 'Name' from which slug is generated</param>
        /// <param name="destination">Category entity model to map category input model into</param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>The formatted Slug field valid for category entity model as string</returns>
        public string Resolve(CategoryInputModel source, Category destination, string destMember, ResolutionContext context) =>
            source.Name.ToLower().Replace(' ','-');
    }
}
