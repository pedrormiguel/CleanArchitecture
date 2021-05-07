using System;
using System.IO;

namespace Application.Features.Orders.Queries.GetOrdersForMonthToExcel
{
    public class OrdersForMonthToExcelvm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }

        public OrdersForMonthToExcelvm()
        {
        }
    }
}
