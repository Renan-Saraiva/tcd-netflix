using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Entities;

namespace Netflix.Infrastructure.DB.Repository.Movies
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {

        }
        
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
