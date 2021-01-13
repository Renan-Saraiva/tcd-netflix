using Netflix.Domain.Entities;
using Netflix.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Netflix.Infrastructure.Abstractions.DB
{
    public interface IMovieRepository : IRepository<Movie>
    {

        public Task<IList<Movie>> Filter(Guid? categoryId, string text);
        public Task<Movie> Like(Guid id);

        public Task<Movie> Unlike(Guid id);

        public Task<Movie> SetWatchStatus(Guid id, MovieStatus movieStatus);

        public Task<IList<Movie>> WasWatched();

    }
}
