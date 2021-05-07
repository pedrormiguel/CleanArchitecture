using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Orders.Queries.GetOrdersForMonth;
using Application.Features.Orders.Queries.GetOrdersForMonthToExcel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediaR;

        public OrderController(IMediator mediaR)
        {
            _mediaR = mediaR;
        }

        [HttpGet("all", Name = "GetAllOrders")]
        public async Task<ActionResult<GetOrderForMonthResponse>> GetAllOrders()
        {
            var dtos = await _mediaR.Send(new GetOrderForMonthQuery());

            return Ok(dtos);
        }

        [HttpGet("GetOrdersExcel", Name = "GetExcellWithAllOrders")]
        public async Task<IActionResult> GetExcelWithAllOrders()
        {
            var file = await _mediaR.Send(new GetOrdersForMonthToExcelQuery());

            return File(Encoding.UTF8.GetBytes(file.ToString()), "text/csv", "orders.csv");
        }
    }
}
