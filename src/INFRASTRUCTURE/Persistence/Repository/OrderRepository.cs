using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(GlobalTicketDbContext globalTicket) : base(globalTicket)
        {
            
        }
    }
}