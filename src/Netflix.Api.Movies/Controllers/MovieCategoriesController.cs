using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Domain;
using Netflix.Infrastructure.DB.Repository.Movie;

namespace Netflix.Api.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCategoriesController : BaseMoviesController<MovieCategory, MovieCategoryRepository>
    {
        public MovieCategoriesController(MovieCategoryRepository repository) : base(repository)
        {
        }

    }
}
