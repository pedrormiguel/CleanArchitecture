using System;
using Domain.Entities;

namespace Application.Persistence.Contracts
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {

    }
}
