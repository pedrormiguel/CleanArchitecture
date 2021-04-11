using System;
using MediatR;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : EventCreateVm, IRequest<Guid>
    {

    }
}