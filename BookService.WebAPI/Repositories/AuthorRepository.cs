using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>
    {
        //private BookServiceContext _bookServiceContext;

        public AuthorRepository(BookServiceContext bookServiceContext) : base(bookServiceContext)
        {
            //_bookServiceContext = bookServiceContext;
        }
        
        public async Task<List<AuthorBasicDto>> ListBasic()
        {
            return await _bookServiceContext.Authors.Select(a => new AuthorBasicDto
            {
                Id = a.Id,
                Name = $"{a.LastName} {a.FirstName}"
            }).ToListAsync();
        }
    }
}
