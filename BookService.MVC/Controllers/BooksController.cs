using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.MVC.Models;
using BookService.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookService.MVC.Controllers
{
    public class BooksController : Controller
    {
        string baseUri = "https://localhost:5001/api/books";
        public IActionResult Index()
        {
            string bookUri = $"{baseUri}/basic";

            return View(WebApiService.GetApiResult<List<BookBasicDto>>(bookUri));
        }

        public IActionResult Detail(int id)
        {
            string geekJokesUri = "https://geek-jokes.sameerkumar.website/api";
            string ipsumUri = "https://baconipsum.com/api/?type=meat-andfiller&paras=2&format=text";
            string bookUri = $"{baseUri}/detail/{id}";
            return View(new BooksDetailViewModel
            {
                BookDetail = WebApiService.GetApiResult<BookDetail>(bookUri),
                AuthorJoke = WebApiService.GetApiResult<string>(geekJokesUri),
                BookSummary = new HttpClient().GetStringAsync(ipsumUri).Result 
            });
        }

    }
}