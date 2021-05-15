using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly GlobalTicketDbContext _globalTicket;

        public CategoryRepository(GlobalTicketDbContext globalTicket) : base(globalTicket)
        {
            _globalTicket = globalTicket;
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithEvents(bool includePassEvents)
        {
            var allCategories = await _globalTicket.Categories.Include(x => x.Events).ToListAsync();

            if (includePassEvents)
                return allCategories.Where(c => c.Events.Any(e => e.Date >= DateTime.Now));

            return allCategories;
        }

        public async Task<bool> IsCategoryNameUnique(string name)
        {
            return await GlobalTicket.Categories.AnyAsync(x => x.Name.Equals(name));
        }
    }
}