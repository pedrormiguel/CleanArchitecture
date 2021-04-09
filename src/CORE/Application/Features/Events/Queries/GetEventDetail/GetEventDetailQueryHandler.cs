using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEvenDetailQuery, EventDetailVm>
    {
<<<<<<< HEAD:src/CORE/Application/Features/Events/GetEventDetail/GetEventDetailQueryHandler.cs
        private readonly IMapper _autoMapper;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Event> _eventRepository;
=======
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _autoMapper;
>>>>>>> 3.0-CQRS:src/CORE/Application/Features/Events/Queries/GetEventDetail/GetEventDetailQueryHandler.cs

        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository,
            IAsyncRepository<Category> categoryRepository, IMapper autoMapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _autoMapper = autoMapper;
        }

        public async Task<EventDetailVm> Handle(GetEvenDetailQuery request, CancellationToken cancellationToken)
        {
            var eventDetail = await _eventRepository.GetByIdAsync(request.Id);

            var eventDetailDto = _autoMapper.Map<EventDetailVm>(eventDetail);

            var category = await _categoryRepository.GetByIdAsync(eventDetailDto.CategoryId);

            eventDetailDto.Category = _autoMapper.Map<CategoryDto>(category);

            return eventDetailDto;
        }
    }
}