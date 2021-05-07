using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Infrastructure;
using Application.Features.Orders.Queries.GetOrdersForMonthToExcel;
using Domain.Entities;

namespace GlobalTicket.Infrastructure.Export.Excel
{
    public class ExportToExcelServices : IExportToExcelServices
    {
        public ExportToExcelServices()
        {
        }

        public StringBuilder GetOrderToExcel(IEnumerable<OrdersForMonthToExcelvm> orders)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Id,UserId,OrderTotal,OrderPlaced,OrderPaid");

            foreach (var order in orders)
            {
                stringBuilder.AppendLine($"{order.Id},{order.UserId},{order.OrderTotal},{order.OrderPlaced},{order.OrderPaid}");
            }

            return stringBuilder;
        }
    }
}
