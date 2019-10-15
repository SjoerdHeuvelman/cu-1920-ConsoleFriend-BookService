using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookService.MVC.Controllers
{
    public class PublishersController : Controller
    {
        string baseUri = "https://localhost:5001/api/publisher";
        public IActionResult Index()
        {
            string publisherUri = $"{baseUri}/basic";
            return View(WebApiService.GetApiResult<List<PublisherBasicDto>>(publisherUri));
        }

        public IActionResult Detail(int id)
        {
            string publisherUri = $"{baseUri}/{id}";
            return View(WebApiService.GetApiResult<Publisher>(publisherUri));
        }
    }
}