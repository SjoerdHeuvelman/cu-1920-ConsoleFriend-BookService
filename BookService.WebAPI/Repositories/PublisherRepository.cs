using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.WebAPI.Data;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository : RepositoryMapping<Publisher>
    {
        public PublisherRepository(BookServiceContext bookServiceContext, IMapper mapper) :base(bookServiceContext, mapper)
        {            
        }

        public async Task<List<PublisherBasicDto>> ListBasic()
        {
            return await _bookServiceContext.Publishers
                .ProjectTo<PublisherBasicDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
