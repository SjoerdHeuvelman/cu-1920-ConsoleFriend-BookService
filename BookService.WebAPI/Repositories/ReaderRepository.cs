using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class ReaderRepository : RepositoryBase<Reader>
    {
        public ReaderRepository(BookServiceContext bookServiceContext) : base(bookServiceContext)
        {
        }
    }
}
