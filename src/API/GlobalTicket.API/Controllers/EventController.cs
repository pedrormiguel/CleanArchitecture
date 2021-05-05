using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Events.Commands.CreateEvent;
using Application.Features.Events.Commands.DeleteEvent;
using Application.Features.Events.Commands.UpdateEvent;
using Application.Features.Events.Queries.GetEventDetail;
using Application.Features.Events.Queries.GetEventList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public EventController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("all", Name = "GetEventList")]
        public async Task<ActionResult<List<EventListVm>>> GetEventList()
        {
            var dtos = await _mediatR.Send(new GetEventsListQuery());

            return Ok(dtos);
        }

        [HttpGet("detail", Name = "GetEventDetails")]
        public async Task<ActionResult<EventDetailVm>> GetEventDetails([FromQuery] string Id)
        {
            var dto = await _mediatR.Send(new GetEvenDetailQuery(Id));

            return Ok(dto);
        }

        [HttpPost("add", Name = "CreateEvent")]
        public async Task<ActionResult<CreateEventCommandResponse>> AddEvent([FromBody] CreateEventCommand createEvent)
        {
            var dto = await _mediatR.Send(new CreateEventCommand()
            {
                Name = createEvent.Name,
                Price = createEvent.Price,
                Artist = createEvent.Artist,
                Description = createEvent.Description,
                ImageUrl = createEvent.ImageUrl,
                Date = createEvent.Date,
                CategoryId = createEvent.CategoryId

            });

            return Ok(dto);
        }

        [HttpDelete("delete", Name = "DeleteEvent")]
        public async Task<ActionResult<DeleteEventCommandResponse>> DeleteEvent([FromQuery] string Id)
        {
            var dto = await _mediatR.Send(new DeleteEventCommand(Id));

            return Ok(dto);
        }

        [HttpPut("update", Name = "UpdateEvent")]
        public async Task<ActionResult<UpdateEventeCommandResponse>> UpdateEvent([FromQuery] string Id, [FromBody] EventUpdateVm eventUpdateVm)
        {
            var dto = await _mediatR.Send(new UpdateEventCommand(Id, eventUpdateVm));

            return Ok(dto);
        }
    }
}
