﻿using System.ComponentModel.DataAnnotations;

namespace BookService.Lib.Models
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "#")]
        public int NumberOfPages { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string FileName { get; set; }
    }
}