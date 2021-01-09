using System;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;
using Netflix.Infrastructure.DB.Repository.Movies;

namespace Netflix.Api.Movies.Controllers
{
    [Route("api/movies/categories")]
    [ApiController]
    public class MoviesCategoriesController : BaseMoviesController<MovieCategory, IRepository<MovieCategory>>
    {
        public MoviesCategoriesController(IRepository<MovieCategory> repository) : base(repository)
        {
        }

        /// <summary>
        /// Possibilidade de exibir os filmes mais vistos por categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/top-viewed")]
        public IActionResult Get([FromRoute]Guid id, [FromQuery]int? top = 5)
        {
            return Ok();
        }
    }
}
