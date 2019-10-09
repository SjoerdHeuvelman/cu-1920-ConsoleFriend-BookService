using System.Threading.Tasks;
using BookService.Lib.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerCrudBase<Publisher, PublisherRepository>
    {    

        public PublisherController(PublisherRepository publisherRepository): base(publisherRepository)
        {            
        }

        // GET: api/Publisher/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetPublishersBasic()
        {
            return Ok(await repository.ListBasic());
        }

    }
}