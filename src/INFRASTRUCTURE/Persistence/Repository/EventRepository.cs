using System;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly GlobalTicketDbContext _globalTicket;

        public EventRepository(GlobalTicketDbContext globalTicket) : base(globalTicket)
        {
            _globalTicket = globalTicket;
        }

        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            return await _globalTicket.Events.FirstAsync(e => e.Name == name) != null;
        }
    }
}