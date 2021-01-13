using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Entities;
using Netflix.Domain.Enum;
using Netflix.Infrastructure.Abstractions.DB;

namespace Netflix.Api.Movies.Controllers
{
    [Route("api/movies")]
    public class MoviesController : BaseController<Movie, IMovieRepository>
    {
        public MoviesController(IMovieRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Busca filmes de um determinado gênero ou palavra-chave
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet("/filter")]
        public async Task<IActionResult> List(
            [FromQuery] Guid? categoryId,
            [FromQuery] string text)
        {
            return Ok(await _repository.Filter(categoryId, text));
        }

        /// <summary>
        /// Possibilita marcar "como gostei" um filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna os dados atualizados do filme</returns>
        [HttpPut("{id}/like")]
        public async Task<IActionResult> Like([FromRoute]Guid id) 
            => Ok(await _repository.Like(id));

        /// <summary>
        /// Possibilita marcar como "não gostei" um filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna os dados atualizados do filme</returns>
        [HttpPut("{id}/unlike")]
        public async Task<IActionResult> Unlike([FromRoute] Guid id)
         => Ok(await _repository.Unlike(id));

        /// <summary>
        /// Marca um filme para assistir depois
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna os dados atualizados do filme</returns>
        [HttpPut("{id}/to-watch")]
        public async Task<IActionResult> ToWatch([FromRoute] Guid id)
            => Ok(await _repository.SetWatchStatus(id, MovieStatus.ToWatch));

        /// <summary>
        /// Marca um filme como não assistido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna os dados atualizados do filme</returns>
        [HttpPut("{id}/unwatch")]
        public async Task<IActionResult> Unwatch([FromRoute] Guid id)
            => Ok(await _repository.SetWatchStatus(id, MovieStatus.Unwatch));

        /// <summary>
        /// Marca um filme como já assistido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna os dados atualizados do filme</returns>
        [HttpPut("{id}/watched")]
        public async Task<IActionResult> Watched([FromRoute] Guid id)
            => Ok(await _repository.SetWatchStatus(id, MovieStatus.Watched));

        /// <summary>
        /// Lista todos os filmes e séries que já foram assistidos;
        /// </summary>
        /// <returns>Retorna uma lista de filmes séries assistidos</returns>
        [HttpGet("watched")]
        public async Task<IActionResult> GetWatched()
            => Ok(await _repository.WasWatched());
    }
}
