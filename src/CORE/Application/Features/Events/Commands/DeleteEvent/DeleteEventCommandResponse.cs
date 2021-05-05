using System;
using Application.Responses;

namespace Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandResponse : BaseResponse
    {
        public DeleteEventCommandResponse() : base(message: "Event Deleted")
        {
        }
    }
}
