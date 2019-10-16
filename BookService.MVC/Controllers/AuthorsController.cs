﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using BookService.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookService.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        string baseuri = "https://localhost:5001/api/authors";
        public IActionResult Index()
        {
            string uri = $"{baseuri}/basic";
            return View(WebApiService.GetApiResult<List<AuthorBasicDto>>(uri));
        }
    }
}