using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            ViewBag.Mode = "Detail";
            return View(WebApiService.GetApiResult<Publisher>(publisherUri));
        }

        public IActionResult Edit(int id)
        {
            string publisherUri = $"{baseUri}/{id}";
            ViewBag.Mode = "Edit";
            return View(nameof(Detail), WebApiService.GetApiResult<Publisher>(publisherUri));
        }

        public IActionResult Insert()
        {
            ViewBag.Mode = "Edit";
            return View(nameof(Detail), new Publisher());
        }

        [HttpPost]
        public async Task<IActionResult> Save(Publisher publisher)
        {
            if (publisher.Id != 0)
            {
                string uri = $"{baseUri}/{publisher.Id}";
                publisher = await WebApiService.PutCallApi<Publisher, Publisher>(uri, publisher);
            }
            else
            {
                publisher = await WebApiService.PostCallApi<Publisher, Publisher>(baseUri, publisher);
            }
            ViewBag.Mode = "Detail";
            return View(nameof(Detail), publisher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            string uri = $"{baseUri}/{id}";
            Publisher publisher = await WebApiService.DeleteCallApi<Publisher>(uri);
            return RedirectToAction(nameof(Index));
        }
    }
}