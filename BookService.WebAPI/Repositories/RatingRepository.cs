using BookService.WebAPI.Data;
using BookService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
