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
    public class BooksController : ControllerBase
    {
        readonly BookRepository _bookRepository;

        public BooksController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookRepository.List());
        }

        // GET: api/Books/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBooksBasic()
        {
            return Ok(_bookRepository.ListBasic());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookDetail(int id)
        {
            return Ok(_bookRepository.GetById(id));
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
        public IActionResult GetImageByBookId(int bookid)
        {            
            return GetImageByFileName(_bookRepository.GetById(bookid).FileName);
        }
    }
}