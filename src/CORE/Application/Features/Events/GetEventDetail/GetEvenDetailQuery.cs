using System;
using Application.Features.Events.Queries.GetEventDetail;
using MediatR;

namespace Application.Features.Events.GetEventDetail
{
    public class GetEvenDetailQuery : IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}