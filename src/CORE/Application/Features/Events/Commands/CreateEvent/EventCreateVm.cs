using System;
using Application.Features.Events.Queries.GetEventDetail;

namespace Application.Features.Events.Commands.CreateEvent
{
    public abstract class EventCreateVm
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Guid CategoryId { get; set; }
    }
}