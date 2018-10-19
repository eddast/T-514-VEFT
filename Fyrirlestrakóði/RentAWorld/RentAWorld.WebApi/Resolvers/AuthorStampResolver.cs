using AutoMapper;
using RentAWorld.Models.DTOs;
using RentAWorld.Models.Entities;

namespace RentAWorld.WebApi.Resolvers
{
    public class AuthorStampResolver : IValueResolver<Rental, RentalDTO, string>
    {
        public string Resolve(Rental source, RentalDTO destination, string destMember, ResolutionContext context)
        {
            return $"{source.DateModified} - {source.ModifiedBy}";
        }
    }
}