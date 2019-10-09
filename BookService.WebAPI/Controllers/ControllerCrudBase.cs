using BookService.Lib.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookService.WebAPI.Controllers
{
    public class ControllerCrudBase<T, R> : ControllerBase
        where T : EntityBase
        where R : RepositoryBase<T>
    {
        protected R repository;

        public ControllerCrudBase(R repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await repository.ListAll());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetById(id));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != entity.Id)
            {
                return BadRequest();
            }

            T updatedEntity = await repository.Update(entity);
            if(updatedEntity == null)
            {
                return NotFound();
            }
            return Ok(updatedEntity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            T createdEntity = await repository.Add(entity);
            if (createdEntity == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            T deletedEntity = await repository.Delete(id);
            if (deletedEntity == null)
            {
                return NotFound();
            }
            return Ok(deletedEntity);
        }
    }
}
