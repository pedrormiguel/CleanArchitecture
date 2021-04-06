using System;
using Domain.Entities;

namespace Application.Persistence.Contracts
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
    }
}
