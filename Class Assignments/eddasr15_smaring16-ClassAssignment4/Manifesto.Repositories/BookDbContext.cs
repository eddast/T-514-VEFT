using System;
using System.Collections.Generic;
using Manifesto.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manifesto.Repositories
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=../Manifesto.Repositories/BookDb.db");
        }
    }
}