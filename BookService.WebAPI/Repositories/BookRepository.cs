using System.Collections.Generic;
using System.Linq;
using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository
    {
        private BookServiceContext _bookServiceContext;

        public BookRepository(BookServiceContext bookServiceContext)
        {
            _bookServiceContext = bookServiceContext;
        }
        public List<Book> List()
        {
            // return a list of books with all Book-properties
            return _bookServiceContext.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
        }
        public List<BookBasicDto> ListBasic()
        {             
            // return a list of BookBasic DTO-items (Id and Title only)
            return _bookServiceContext.Books.Select(b => new BookBasicDto { Id = b.Id, Title = b.Title }).ToList();
        }

        public BookDetail GetById(int id)
        {
            return _bookServiceContext.Books.Select(b => new BookDetail
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Year = b.Year,
                Price = b.Price,
                NumberOfPages = b.NumberOfPages,
                AuthorId = b.Author.Id,
                AuthorName = $"{b.Author.LastName} {b.Author.FirstName}",
                PublisherId = b.Publisher.Id,
                PublisherName = b.Publisher.Name,
                FileName = b.FileName
            }).FirstOrDefault(b => b.Id == id);
        }
    }
}
