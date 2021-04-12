using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _autoMapper;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper autoMapper)
        {
            _eventRepository = eventRepository;
            _autoMapper = autoMapper;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var eventMapped = _autoMapper.Map<Event>(request);

            await _eventRepository.AddAsync(eventMapped);

            return eventMapped.EventId;
        }
    }
}