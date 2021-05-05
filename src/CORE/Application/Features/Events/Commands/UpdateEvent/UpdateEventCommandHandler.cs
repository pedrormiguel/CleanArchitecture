using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdateEventeCommandResponse>
    {
        private readonly IAsyncRepository<Event> _eventRepository;

        public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<UpdateEventeCommandResponse> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var EventToUpdate = await _eventRepository.GetByIdAsync(request.Id);

            if (EventToUpdate == null)
                throw new Exception();

            await _eventRepository.UpdateAsync(EventToUpdate);

            return new UpdateEventeCommandResponse() { EventUpdateVm = request.UpdateEvent };
        }
    }
}
