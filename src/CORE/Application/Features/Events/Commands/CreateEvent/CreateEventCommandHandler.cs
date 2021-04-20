using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Models.Mail;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _autoMapper;
        private readonly IEmailServices _emailServices;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper autoMapper, IEmailServices emailServices)
        {
            _eventRepository = eventRepository;
            _autoMapper = autoMapper;
            _emailServices = emailServices;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var eventMapped = _autoMapper.Map<Event>(request);

            await _eventRepository.AddAsync(eventMapped);

            var email = new Email
            {
                To = "pedrormiguel@outlook.es", 
                Subject = $"An new Event was created: {request.Name}", 
                Body = $"Hi, It's a new Event {request}"
            };
            
            try
            {
                await _emailServices.SendEmail(email);
            }
            catch(Exception e)
            { 
                //TODO this shouldn't stop the API from doing else so this can be logged 
            }

            return eventMapped.EventId;
        }
    }
}