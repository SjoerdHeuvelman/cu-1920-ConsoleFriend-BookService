using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository
    {
        private BookServiceContext _bookServiceContext;

        public PublisherRepository(BookServiceContext bookServiceContext)
        {
            _bookServiceContext = bookServiceContext;
        }

        public List<Publisher> List()
        {
            return _bookServiceContext.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return _bookServiceContext.Publishers.Find(id);
        }

        public async Task<Publisher> Update(Publisher publisher)
        {
            try
            {
                _bookServiceContext.Entry(publisher).State = EntityState.Modified;
                await _bookServiceContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(publisher.Id))
                {
                    return null;
                }
                
                throw;
            }
            return publisher;
        }

        public async Task<Publisher> Add(Publisher publisher)
        {
            _bookServiceContext.Publishers.Add(publisher);
            await _bookServiceContext.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher> Delete(int id)
        {
            var publisher = await _bookServiceContext.Publishers.FindAsync(id);
            if(publisher == null)
            {
                return null;
            }

            _bookServiceContext.Publishers.Remove(publisher);
            await _bookServiceContext.SaveChangesAsync();
            return publisher;
        }

        private bool PublisherExists(int id)
        {
            return _bookServiceContext.Publishers.Any(p => p.Id == id);
        }
    }
}
