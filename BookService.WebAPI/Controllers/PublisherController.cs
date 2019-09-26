using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        readonly PublisherRepository _publisherRepository;

        public PublisherController(PublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        // GET: api/Publisher
        [HttpGet]
        public async Task<IActionResult> GetPublishers()
        {
            return Ok(await _publisherRepository.ListAll());
        }

        // GET: api/Publisher/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher(int id)
        {
            return Ok(await _publisherRepository.GetById(id));
        }

        //PUT: api/Publisher/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher([FromRoute]int id, [FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != publisher.Id)
            {
                return BadRequest();
            }

            var updatedPublisher = await _publisherRepository.Update(publisher);
            if(updatedPublisher == null)
            {
                return NotFound();
            }

            return Ok(updatedPublisher); 
        }

        //POST: api/Publisher
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _publisherRepository.Add(publisher);

            return CreatedAtAction(nameof(GetPublisher), new { id = publisher.Id }, publisher);
        }

        //DELETE: api/Publisher/4
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisher = await _publisherRepository.Delete(id);
            if(publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);            
        }
    }
}