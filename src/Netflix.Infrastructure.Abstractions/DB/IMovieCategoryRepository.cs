using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Netflix.Domain.Entities;

namespace Netflix.Infrastructure.Abstractions.DB
{
    public interface IMovieCategoryRepository : IRepository<MovieCategory>
    {
        Task<IList<Movie>> TopViewed(Guid id, int top);
    }
}