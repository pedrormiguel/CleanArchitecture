using System.Collections.Generic;
using System.IO;
using System.Text;
using Application.Features.Orders.Queries.GetOrdersForMonthToExcel;
using Application.Models.Export;

namespace Application.Contracts.Infrastructure
{
    public interface IExportToExcelServices
    {
        ExcelFile GetOrderToExcel(IEnumerable<OrdersForMonthToExcelvm> orders);
    }
}
