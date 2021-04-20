using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
    {
        private readonly GlobalTicketDbContext _globalTicket;

        public CategoryRepository(GlobalTicketDbContext globalTicket) : base(globalTicket)
        {
            _globalTicket = globalTicket;
        }

        public async Task<IEnumerable<Category>> GetCatgoriesWithEvents(bool includePassEvents)
        {
            if(includePassEvents)
                return await _globalTicket.Categories.ToListAsync();
            else
            {
                return (await _globalTicket.Categories.ToArrayAsync())
                    .Where
                    (  
                        // c => c.Events.SelectMany( x => x.Date > DateTime.Now, categories)
                        c => c.Events.Any( x => x.Date >= DateTime.Now )
                    );
            }
        }

        public async Task<bool> IsCategoryNameUnique(string name)
        {
            return await GlobalTicket.Categories.AnyAsync( x => x.Name.Equals(name) );
        }
    }
}