using System;

<<<<<<< HEAD:src/CORE/Application/Features/Events/GetEventDetail/EventDetailVm.cs
namespace Application.Features.Events.GetEventDetail
=======
namespace Application.Features.Events.Queries.GetEventDetail
>>>>>>> 3.0-CQRS:src/CORE/Application/Features/Events/Queries/GetEventDetail/EventDetailVm.cs
{
    public class EventDetailVm
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}