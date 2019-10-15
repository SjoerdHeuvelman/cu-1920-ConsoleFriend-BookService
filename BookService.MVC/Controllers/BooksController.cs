using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.MVC.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookService.MVC.Controllers
{
    public class BooksController : Controller
    {
        string baseUri = "https://localhost:4200/api/books";
        public IActionResult Index()
        {
            string bookUri = $"{baseUri}/basic";
            return View(GetApiResult<List<BookBasicDto>>(bookUri));
        }

        public IActionResult Detail(int id)
        {
            string geekJokesUri = "https://geek-jokes.sameerkumar.website/api"; 
            string ipsumUri = "https://baconipsum.com/api/?type=meat-and-filler&paras=2&format=text"; 
            string bookUri = $"{baseUri}/detail/{id}";

            var viewModel = new BookDetailViewModel
            {
                BookDetail = GetApiResult<BookDetail>(bookUri),
                AuthorJoke = GetApiResult<string>(geekJokesUri),
                BookSummary = new HttpClient().GetStringAsync(ipsumUri).Result
            };

            return View(viewModel);
        }

        private T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient()) 
            { 
                Task<String> response = httpClient.GetStringAsync(uri); 
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Result)).Result; 
            }
        }
    }
}