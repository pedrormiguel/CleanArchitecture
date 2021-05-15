using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithEvents(bool includePassEvents);
        Task<bool> IsCategoryNameUnique(string name);
    }
}