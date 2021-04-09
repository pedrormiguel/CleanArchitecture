using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventCreateVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _autoMapper;

        public CreateEventCommandHandler(IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository, IMapper autoMapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _autoMapper = autoMapper;
        }

        public async Task<EventCreateVm> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            
            var eventMapped = _autoMapper.Map<Event>(request);

            await _eventRepository.AddAsync(eventMapped);

            return _autoMapper.Map<EventCreateVm>(eventMapped);
        }
    }
}