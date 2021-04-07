using System;
using MediatR;

namespace Application.Features.Events.GetEventDetail
{
    public class GetEvenDetailQuery : IRequest<EventDetailVm>
    {
        public Guid Id {get; set;}
    }
}
