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
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _autoMapper;

        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository, IMapper autoMapper)
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