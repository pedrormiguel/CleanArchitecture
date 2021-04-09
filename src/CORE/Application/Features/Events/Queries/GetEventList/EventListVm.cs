using System;

<<<<<<< HEAD:src/CORE/Application/Features/Events/GetEventList/EventListVm.cs
namespace Application.Features.Events
=======
namespace Application.Features.Events.Queries.GetEventList
>>>>>>> 3.0-CQRS:src/CORE/Application/Features/Events/Queries/GetEventList/EventListVm.cs
{
    //Class that serve as DTO
    //It's just show the information that I want.
    public class EventListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}