using System;
using MediatR;

namespace Application.Features.Events.Queries.GetEventDetail
{
    public class GetEvenDetailQuery : IRequest<EventDetailVm>
    {
        public GetEvenDetailQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id {get; private set;}
    }
}
