using System.Collections.Generic;
using Application.Responses;

namespace Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class GetOrderForMonthResponse : BaseResponse
    {
        public GetOrderForMonthResponse() : base()
        {
            
        }

        public List<OrderForMothVm> OrderForMothVm { get; set; }
    }
}