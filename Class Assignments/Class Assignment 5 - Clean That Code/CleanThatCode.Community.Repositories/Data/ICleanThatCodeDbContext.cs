using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities;

namespace CleanThatCode.Community.Repositories.Data
{
    public interface ICleanThatCodeDbContext
    {
         IEnumerable<Comment> Comments { get; }
         IEnumerable<Post> Posts { get; }
    }
}