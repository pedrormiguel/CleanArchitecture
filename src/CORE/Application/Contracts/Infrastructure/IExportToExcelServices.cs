using System.Collections.Generic;
using System.Text;
using Application.Features.Orders.Queries.GetOrdersForMonthToExcel;

namespace Application.Contracts.Infrastructure
{
    public interface IExportToExcelServices
    {
        StringBuilder GetOrderToExcel(IEnumerable<OrdersForMonthToExcelvm> orders);
    }
}
