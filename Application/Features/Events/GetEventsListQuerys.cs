using System.Collections.Generic;
using MediatR;

namespace Application.Features.Events
{
    //It's is the message to Send.
    //The parameter is the CustomClass with jus the property need it.
    public class GetEventsListQuerys : IRequest<List<EventListVm>>
    {

    }
}
