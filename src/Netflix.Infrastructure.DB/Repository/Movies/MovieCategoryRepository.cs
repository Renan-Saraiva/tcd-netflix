using Netflix.Domain.Entities;

namespace Netflix.Infrastructure.DB.Repository.Movies
{
    public class MovieCategoryRepository : NetflixRepository<MovieCategory, MovieContext>
    {
        public MovieCategoryRepository(MovieContext context) : base(context)
        {

        }
    }
}
