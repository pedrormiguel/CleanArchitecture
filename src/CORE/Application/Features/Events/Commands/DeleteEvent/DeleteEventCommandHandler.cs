using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository;

        public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDeleted = await _eventRepository.GetByIdAsync(request.Id);

            if (eventToDeleted == null)
                throw new Exception();

            await _eventRepository.DeleteAsync(eventToDeleted);

            return Unit.Value;
        }
    }
}
