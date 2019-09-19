using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class AuthorRepository
    {
        private BookServiceContext _bookServiceContext;

        public AuthorRepository(BookServiceContext bookServiceContext)
        {
            _bookServiceContext = bookServiceContext;
        }
        public List<Author> List()
        {            
            return _bookServiceContext.Authors.ToList();
        }

        public List<AuthorBasicDto> ListBasic()
        {
            return _bookServiceContext.Authors.Select(a => new AuthorBasicDto
            {
                Id = a.Id,
                Name = $"{a.LastName} {a.FirstName}"
            }).ToList();
        }

        public Author GetById(int id)
        {
            return _bookServiceContext.Authors.Find(id);
        }
    }
}
