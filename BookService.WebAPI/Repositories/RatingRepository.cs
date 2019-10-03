using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class RatingRepository : RepositoryBase<Rating>
    {
        public RatingRepository(BookServiceContext bookServiceContext) : base(bookServiceContext)
        {
        }

        public async Task<List<Rating>> GetAllInclusive()
        {
            return await GetAll()
                .Include(r => r.Book)
                .Include(r => r.Reader)
                .ToListAsync();
        }
    }
}
