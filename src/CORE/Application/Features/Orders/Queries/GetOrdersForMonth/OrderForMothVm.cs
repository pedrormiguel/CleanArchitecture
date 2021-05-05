using System;

namespace Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class OrderForMothVm
    {
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}