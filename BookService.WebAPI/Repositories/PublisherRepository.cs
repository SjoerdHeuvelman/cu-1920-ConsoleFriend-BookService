using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>
    {
        public PublisherRepository(BookServiceContext bookServiceContext) :base(bookServiceContext)
        {            
        }        
    }
}
