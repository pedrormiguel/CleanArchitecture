using System.Collections.Generic;
using MediatR;

namespace Application.Features.Events
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {

    }
}
