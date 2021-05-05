using System;
using MediatR;

namespace Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest<UpdateEventeCommandResponse>
    {
        public Guid Id { get; set; }
        public EventUpdateVm UpdateEvent { get; }


        public UpdateEventCommand(string id, EventUpdateVm updateEventCommand)
        {
            Id = new Guid(id);
            UpdateEvent = updateEventCommand;
        }
    }
}
