using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return Ok(_publisherRepository.List());
        }

        // GET: api/Publisher/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher(int id)
        {
            return Ok(_publisherRepository.GetById(id));
        }
    }
}