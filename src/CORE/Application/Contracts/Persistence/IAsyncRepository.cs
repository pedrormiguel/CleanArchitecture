using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid Id);

        // --------------------------
        Task<IReadOnlyList<T>> ListAllAsync();
        //--------------------------

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
