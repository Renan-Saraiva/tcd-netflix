using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;
using Netflix.Infrastructure.Abstractions.Messaging;
using Netflix.Infrastructure.DB.Repository.Movies;

namespace Netflix.Api.Movies.Controllers
{
    /// <summary>
    /// Possibilidade de visualizar os filmes de um determinado gênero;
    /// Possibilidade de visualizar os detalhes de cada filme;
    /// Possibilidade de votar nos filmes que mais gostei;
    /// Possibilidade de marcar um filme ou série para ser visto no futuro;
    /// Possibilidade de buscar um filme por palavra-chave;
    /// Possibilidade de exibir os filmes mais vistos por categorias;
    /// Possibilidade de abrir um chamado técnico de algum problema que está acontecendo;
    /// Possibilidade de visualizar os filmes e séries que já foram assistidos;
    /// TODO: Remover
    /// </summary>
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : BaseMoviesController<Movie, IRepository<Movie>>
    {
        public MoviesController(IRepository<Movie> repository) : base(repository)
        {

        }

        /// <summary>
        /// Possibilidade de visualizar os filmes de um determinado gênero
        /// Possibilidade de buscar um filme por palavra-chave (Deixar por ultimo)
        /// </summary>
        /// <param name="category"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet("/filter")]
        public IActionResult List(
            [FromQuery] int? category,
            [FromQuery] string text)
        {
            return Ok();
        }

        /// <summary>
        /// Possibilidade de votar nos filmes que mais gostei
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/like")]
        public IActionResult Like([FromRoute]Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Possibilidade de votar nos filmes que mais gostei
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/unlike")]
        public IActionResult Unlike([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPut("{id}/to-watch")]
        public IActionResult ToWatch([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPut("{id}/unwatch")]
        public IActionResult Unwatch([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPut("{id}/watched")]
        public IActionResult Watched([FromRoute] Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Possibilidade de visualizar os filmes e séries que já foram assistidos;
        /// </summary>
        /// <returns></returns>
        [HttpGet("watched")]
        public IActionResult GetWatched()
        {
            return Ok();
        }
    }
}
