using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.WebAPI.Data;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository : RepositoryMapping<Book>
    {        
        public BookRepository(BookServiceContext bookServiceContext, IMapper mapper) : base(bookServiceContext, mapper)
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
            return await _bookServiceContext.Books
                .ProjectTo<BookBasicDto>(_mapper.ConfigurationProvider)
                .OrderBy(b => b.Title)
                .ToListAsync();
        }
         
        public async Task<BookDetail> GetDetailById(int id)
        {
            return _mapper.Map<BookDetail>(
                await _bookServiceContext.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id));                
        }

        public async Task<List<BookStatisticsDto>> ListStatistics()
        {
            return await _bookServiceContext.Books
                    .Include(b => b.Ratings)
                    .Where(b => b.Ratings.Count > 0)
                    .ProjectTo<BookStatisticsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
    }
}
