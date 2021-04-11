using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _autoMapper;

        public CreateEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper autoMapper)
        {
            _eventRepository = eventRepository;
            _autoMapper = autoMapper;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {

            var eventMapped = _autoMapper.Map<Event>(request);

            await _eventRepository.AddAsync(eventMapped);

            return eventMapped.EventId;
        }
    }
}