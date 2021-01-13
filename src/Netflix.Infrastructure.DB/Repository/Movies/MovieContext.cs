using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Entities;
using System;

namespace Netflix.Infrastructure.DB.Repository.Movies
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {

        }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
    }
}
