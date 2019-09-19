using System.Collections.Generic;
using System.Linq;
using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;

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
            return _bookServiceContext.Books.ToList();
        }
        public List<BookBasicDto> ListBasic()
        {             
            // return a list of BookBasic DTO-items (Id and Title only)
            return _bookServiceContext.Books.Select(b => new BookBasicDto { Id = b.Id, Title = b.Title }).ToList();
        }
    }
}
