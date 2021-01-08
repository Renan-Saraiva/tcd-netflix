using Netflix.Domain.Domain;

namespace Netflix.Infrastructure.DB.Repository.Movie
{
    public class MovieCategoryRepository : NetflixRepository<MovieCategory, MovieContext>
    {
        public MovieCategoryRepository(MovieContext context) : base(context)
        {

        }
    }
}
