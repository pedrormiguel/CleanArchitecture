using System;
using MediatR;

namespace Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<DeleteEventCommandResponse>
    {
        public Guid Id { get; set; }

        public DeleteEventCommand(string id)
        {
            Guid idEvent = new Guid(id);

            Id = idEvent;
        }

    }
}
