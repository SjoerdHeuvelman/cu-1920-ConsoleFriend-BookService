using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerCrudBase<Book, BookRepository>
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public BooksController(BookRepository bookRepository, IHostingEnvironment hostingEnvironment) : base(bookRepository)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Books
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }

        // GET: api/Books/Detail/6
        [HttpGet]
        [Route("Detail/{id}")]
        public async Task<IActionResult> GetBookDetail(int id)
        {
            return Ok(await repository.GetDetailById(id));
        }

        // GET: api/Books/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetBooksBasic()
        {
            return Ok(await repository.ListBasic());
        }                           
        
        // GET: api/books/imagebyname/book2.jpg
        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult GetImageByFileName(string filename)
        {
            var pathOfImage = Path.Combine(_hostingEnvironment.WebRootPath, "images", filename);
            return PhysicalFile(pathOfImage, "image/jpeg");
        }

        // GET: api/books/imagebyid/6
        [HttpGet]
        [Route("ImageById/{bookid}")]
        public async Task<IActionResult> GetImageById(int bookid)
        {
            BookDetail book = await repository.GetDetailById(bookid);
            return GetImageByFileName(book.FileName);
        }

        [HttpPost]
        [Route("Image")]
        public async Task<IActionResult> Image(IFormFile formFile)
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", formFile.FileName);

            if(formFile.Length > 0)
            {
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            return Ok(new {count = 1, formFile.Length});

        }

        [HttpGet]
        [Route("Statistics")]
        public async Task<IActionResult> GetBookStatistics()
        {
            return Ok(await repository.ListStatistics());
        }
    }
}