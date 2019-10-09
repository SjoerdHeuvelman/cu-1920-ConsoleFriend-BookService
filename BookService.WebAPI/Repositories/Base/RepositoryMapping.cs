using AutoMapper;
using BookService.WebAPI.Data;
using BookService.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class RepositoryMapping<T>: RepositoryBase<T> where T : EntityBase
    {
        protected readonly IMapper _mapper;

        public RepositoryMapping(BookServiceContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}
