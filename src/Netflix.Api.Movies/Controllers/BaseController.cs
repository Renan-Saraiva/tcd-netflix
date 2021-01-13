using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;

namespace Netflix.Api.Movies.Controllers
{
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {

        protected readonly TRepository _repository;

        public BaseController(TRepository repository)
        {
            _repository = repository;
        }

       /// <summary>
       /// Lista todos os itens
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
            => await _repository.GetAll();

        /// <summary>
        /// Busca item pelo id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(Guid id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
                return NotFound();
            
            return Ok(entity);
        }

        /// <summary>
        /// Atualiza item pelo id
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TEntity entity)
        {
            entity.Id = id;
            return Ok(await _repository.Update(entity));
        }

        /// <summary>
        /// Adicionada um novo item
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)       
            => Created("", await _repository.Add(entity));

        /// <summary>
        /// Apaga item pelo id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            var entity = await _repository.Delete(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
    }
}
