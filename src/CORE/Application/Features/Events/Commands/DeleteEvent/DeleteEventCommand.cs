using System;
using MediatR;

namespace Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
