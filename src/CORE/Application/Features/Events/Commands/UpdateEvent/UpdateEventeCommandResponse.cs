using System;
using Application.Responses;

namespace Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventeCommandResponse : BaseResponse
    {
        public UpdateEventeCommandResponse() : base(message: "Event Updated")
        {
        }

        public EventUpdateVm EventUpdateVm { get; set; }
    }
}
