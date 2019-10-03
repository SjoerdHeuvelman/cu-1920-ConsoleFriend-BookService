using System;
using System.Collections.Generic;
using System.IO;
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
    public class BooksController : ControllerCrudBase<Book, BookRepository>
    {       

        public BooksController(BookRepository bookRepository) : base(bookRepository)
        {            
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await repository.GetAllInclusive());
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
            var pathOfImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);
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
    }
}