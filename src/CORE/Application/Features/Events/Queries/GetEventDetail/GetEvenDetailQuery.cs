using System;
using MediatR;

namespace Application.Features.Events.Queries.GetEventDetail
{
    public class GetEvenDetailQuery : IRequest<EventDetailVm>
    {
        public GetEvenDetailQuery(string id)
        {
            var idGuid = new Guid(id);

            Id = idGuid;
        }

        public Guid Id { get; private set; }
    }
}
