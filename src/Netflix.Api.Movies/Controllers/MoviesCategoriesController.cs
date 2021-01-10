using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;

namespace Netflix.Api.Movies.Controllers
{
    [Route("api/movies/categories")]
    public class MoviesCategoriesController : BaseController<MovieCategory, IMovieCategoryRepository>
    {
        public MoviesCategoriesController(IMovieCategoryRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Possibilidade de exibir os filmes mais vistos por categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/top-viewed")]
        public async Task<IActionResult> Get([FromRoute]Guid id, [FromQuery]int top = 5)
             => Ok(await _repository.TopViewed(id, top));
    }
}
