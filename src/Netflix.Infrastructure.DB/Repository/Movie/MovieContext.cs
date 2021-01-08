using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Domain;

namespace Netflix.Infrastructure.DB.Repository.Movie
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<MovieCategory> MovieCategories { get; set; }
    }
}
