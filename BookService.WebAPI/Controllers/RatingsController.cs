using BookService.Lib.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerCrudBase<Rating, RatingRepository>
    {
        public RatingsController(RatingRepository ratingRepository) : base(ratingRepository)
        {
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }

        /*Om een selfreferencing loop te vermijden OPTIE 1
        // GET: api/Ratings
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return Ok(JsonConvert.SerializeObject(await repository.GetAllInclusive(),settings));
        }
        */

    }
}
