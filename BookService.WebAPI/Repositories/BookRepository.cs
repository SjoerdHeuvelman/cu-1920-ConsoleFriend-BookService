using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository : RepositoryBase<Book>
    {        
        public BookRepository(BookServiceContext bookServiceContext) : base(bookServiceContext)
        {            
        }

        public async Task<List<Book>> GetAllInclusive()
        {
            return await GetAll()
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<List<BookBasicDto>> ListBasic()
        {
            return await _bookServiceContext.Books.Select(
                b => new BookBasicDto
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToListAsync();
        }
         
        public async Task<BookDetail> GetDetailById(int id)
        {
            return await _bookServiceContext.Books.Select(b => new BookDetail
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
            }).FirstOrDefaultAsync(b => b.Id == id);
        }        
    }
}
