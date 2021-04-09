using MediatR;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<EventCreateVm>, IRequest<Unit>
    {
        
    }
}