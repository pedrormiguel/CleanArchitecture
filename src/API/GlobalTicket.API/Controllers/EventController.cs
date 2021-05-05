using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            var dto = await _mediatR.Send(new GetEventsListQuery());

            return Ok(dto);
        }
    }
}
