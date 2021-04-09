using System.Collections.Generic;
using MediatR;

namespace Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {

    }
}
