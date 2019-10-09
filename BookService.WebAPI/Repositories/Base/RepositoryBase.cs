using BookService.WebAPI.Data;
using BookService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        protected readonly BookServiceContext _bookServiceContext;

        public RepositoryBase(BookServiceContext bookServiceContext)
        {
            _bookServiceContext = bookServiceContext;
        }


        public async Task<T> Add(T entity)
        {
            _bookServiceContext.Set<T>().Add(entity);
            try
            {
                await _bookServiceContext.SaveChangesAsync();
            }
            catch 
            {
                return null;                
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _bookServiceContext.Set<T>().Remove(entity);
            try
            {
                await _bookServiceContext.SaveChangesAsync();
            }
            catch 
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await GetById(id);
            if(entity == null)
            {
                return null;
            }
            return await Delete(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _bookServiceContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await _bookServiceContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return _bookServiceContext.Set<T>().Where(predicate).AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _bookServiceContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _bookServiceContext.SaveChangesAsync();
            }
            catch 
            {
                return null;
            }
            return entity;
        }

        private async Task<bool> Exists(int id)
        {
            return await _bookServiceContext.Set<T>().AnyAsync(e => e.Id == id);
        }
    }
}
