using Application.Models.Export;
using MediatR;

namespace Application.Features.Orders.Queries.GetOrdersForMonthToExcel
{
    public class GetOrdersForMonthToExcelQuery : IRequest<ExcelFile>
    {
        public GetOrdersForMonthToExcelQuery()
        {

        }


    }
}
