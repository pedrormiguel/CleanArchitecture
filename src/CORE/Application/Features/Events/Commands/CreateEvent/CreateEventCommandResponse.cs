using System;
using Application.Responses;
using FluentValidation.Results;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandResponse : BaseResponse
    {
        public CreateEventCommandResponse() : base()
        {

        }

        public Guid EventId { get; set; }
    }
}
