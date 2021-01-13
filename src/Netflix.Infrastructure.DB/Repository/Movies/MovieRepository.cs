using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Netflix.Domain.Entities;
using Netflix.Domain.Enum;
using Netflix.Infrastructure.Abstractions.DB;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Infrastructure.DB.Repository.Movies
{
    public class MovieRepository : NetflixRepository<Movie, MovieContext>, IMovieRepository
    {
        public MovieRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<List<Movie>> GetAll()
        {
            return await _context.Movies.Include(_ => _.Category).ToListAsync();
        }

        public override async Task<Movie> Add(Movie entity)
        {
            entity.Id = Guid.Empty;
            _context.Movies.Add(entity);
            await _context.SaveChangesAsync();
            return await _context.Movies
                                .Include(_ => _.Category)
                                .FirstOrDefaultAsync(m => m.Id.Equals(entity.Id));
        }

        public override async Task<Movie> Get(Guid id)
        {
            return await _context.Movies
                                .Include(_ => _.Category)
                                .FirstOrDefaultAsync(m => m.Id.Equals(id));
        }

        public override async Task<Movie> Update(Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Movies
                               .Include(_ => _.Category)
                               .FirstOrDefaultAsync(m => m.Id.Equals(entity.Id));
        }

        public async Task<Movie> Like(Guid id)
        {
            var movie = await _context.Movies
                                    .Include(_ => _.Category)
                                    .SingleOrDefaultAsync(_ => _.Id == id);
            movie.Like();

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return movie;

        }

        public async Task<Movie> Unlike(Guid id)
        {
            var movie = await _context.Movies
                                    .Include(_ => _.Category)
                                    .SingleOrDefaultAsync(_ => _.Id == id);
            movie.UnLike();

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> SetWatchStatus(Guid id, MovieStatus movieStatus)
        {
            var movie = await _context.Movies
                                    .Include(_ => _.Category)
                                    .SingleOrDefaultAsync(_ => _.Id == id);
            movie.SetStatus(movieStatus);

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<IList<Movie>> WasWatched()
        {
            var movies = _context.Movies
                                    .Include(_ => _.Category)
                                    .Where(x => x.Status == MovieStatus.Watched)
                                    .OrderBy(x => x.Name)
                                    .ToList();
            return await Task.FromResult<IList<Movie>>(movies);
        }

        public async Task<IList<Movie>> Filter(Guid? categoryId, string text)
        {

            IQueryable<Movie> movies = _context.Movies;

            if (categoryId.HasValue)
            {
                movies = movies.Where(_ => _.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(text))
            {
                movies = movies.Search(_ => _.Name, _ => _.Description).Containing(text);
            }

            movies = movies.Include(_ => _.Category);

            return await Task.FromResult<IList<Movie>>(movies.ToList());
        }
    }
}
