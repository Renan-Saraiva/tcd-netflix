using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;

namespace Netflix.Infrastructure.DB.Repository.Movies
{
    public class MovieRepository : NetflixRepository<Movie, MovieContext>, IMovieRepository
    {
        public MovieRepository(MovieContext context) : base(context)
        {

        }
    }
}
