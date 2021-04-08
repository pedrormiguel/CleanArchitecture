using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events
{
    //It's the Handler of the Message, whose responsability is orquest all the logic to Layers.
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IAsyncRepository<Event> _asyncRepository;
        private readonly IMapper _autoMapper;

        public GetEventsListQueryHandler(IAsyncRepository<Event> asyncRepository, IMapper autoMapper)
        {
            _asyncRepository = asyncRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            //Getting the Data form the Store
            var allEvents = (await _asyncRepository.ListAllAsync()).OrderBy(x => x.Date);

            //Mapping the Raw Data in something that is useful and limited. ( Do not expose our desing table/entity ) )
            return _autoMapper.Map<List<EventListVm>>(allEvents);
        }
    }
}