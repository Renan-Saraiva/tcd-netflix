using Netflix.Domain.Entities;

namespace Netflix.Infrastructure.DB.Repository.Movies
{
    public class MovieRepository : NetflixRepository<Movie, MovieContext>
    {
        public MovieRepository(MovieContext context) : base(context)
        {

        }
    }
}
