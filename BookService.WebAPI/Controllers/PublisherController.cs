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
    public class PublisherController : ControllerCrudBase<Publisher, PublisherRepository>
    {    

        public PublisherController(PublisherRepository publisherRepository): base(publisherRepository)
        {            
        }       
        
    }
}