using System;
using MediatR;

namespace Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest
    {
        public Guid Id { get; set; }

        public UpdateEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
