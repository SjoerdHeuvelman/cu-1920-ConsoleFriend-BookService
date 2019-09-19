using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository
    {
        private BookServiceContext _bookServiceContext;

        public PublisherRepository(BookServiceContext bookServiceContext)
        {
            _bookServiceContext = bookServiceContext;
        }

        public List<Publisher> List()
        {
            return _bookServiceContext.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return _bookServiceContext.Publishers.Find(id);
        }
    }
}
