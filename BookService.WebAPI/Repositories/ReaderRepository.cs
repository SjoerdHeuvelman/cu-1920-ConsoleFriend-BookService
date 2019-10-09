using BookService.WebAPI.Data;
using BookService.Lib.Models;

namespace BookService.WebAPI.Repositories
{
    public class ReaderRepository : RepositoryBase<Reader>
    {
        public ReaderRepository(BookServiceContext bookServiceContext) : base(bookServiceContext)
        {
        }
    }
}
