using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events
{
    //It's the Handler of the Message, whose know how it has to interact each other
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuerys, List<EventListVm>>
    {
        private readonly IAsyncRepository<Event> _eventRespository;
        private readonly IMapper _autoMapper;

        public GetEventsListQueryHandler(IAsyncRepository<Event> eventRespository, IMapper autoMapper)
        {
            _eventRespository = eventRespository;
            _autoMapper = autoMapper;
        }

        public async Task<List<EventListVm>> Handle(GetEventsListQuerys request, CancellationToken cancellationToken)
        {
            //Getting the Data form the Store
            var eventAll = (await _eventRespository.ListAllAsync()).OrderBy(x => x.Date);

            //Mapping the Raw Data in something that is useful and limited. ( Do not expose our desing table )
            return _autoMapper.Map<List<EventListVm>>(eventAll);
        }
    }
}
