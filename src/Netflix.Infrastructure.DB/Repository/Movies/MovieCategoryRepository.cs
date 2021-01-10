using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;

namespace Netflix.Infrastructure.DB.Repository.Movies
{
    public class MovieCategoryRepository : NetflixRepository<MovieCategory, MovieContext>, IMovieCategoryRepository
    {
        public MovieCategoryRepository(MovieContext context) : base(context)
        {

        }

        public Task<IList<Movie>> TopViewed(Guid id, int top)
        {
             var topViewedMovies = _context.Movies
                                           .Where(m => m.Category.Id == id)
                                           .OrderByDescending(m => m.ViewedCount)
                                           .Take(top)
                                           .ToList();

            return Task.FromResult<IList<Movie>>(topViewedMovies);
        }
    }
}
