using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly GlobalTicketDbContext GlobalTicket;
        
        public BaseRepository(GlobalTicketDbContext globalTicket)
        {
            GlobalTicket = globalTicket;
        }
        
        public async Task<T> GetByIdAsync(Guid id)
        {
           return await GlobalTicket.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await GlobalTicket.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
             await GlobalTicket.Set<T>().AddAsync(entity);
             await GlobalTicket.SaveChangesAsync();

             return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            GlobalTicket.Entry(entity).State = EntityState.Modified;

            await GlobalTicket.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            GlobalTicket.Set<T>().Remove(entity);

            await GlobalTicket.SaveChangesAsync();

            return entity;
        }
    }
}