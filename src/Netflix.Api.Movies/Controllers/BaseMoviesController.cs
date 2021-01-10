using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Infrastructure.Abstractions.DB;

namespace Netflix.Api.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseMoviesController<TEntity, TRepository> : ControllerBase
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {

        private readonly TRepository repository;

        public BaseMoviesController(TRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
            => await repository.GetAll();

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(Guid id)
        {
            var movie = await repository.Get(id);
            if (movie == null)
                return NotFound();
            
            return Ok(movie);
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TEntity movie)
            => Ok(await repository.Update(movie));

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity movie)       
            => Created("", await repository.Add(movie));

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            var movie = await repository.Delete(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }
    }
}
