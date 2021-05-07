using System.Text;
using MediatR;

namespace Application.Features.Orders.Queries.GetOrdersForMonthToExcel
{
    public class GetOrdersForMonthToExcelQuery : IRequest<StringBuilder>
    {
        public GetOrdersForMonthToExcelQuery()
        {

        }
    }
}
