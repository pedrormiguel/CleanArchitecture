using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Orders.Queries.GetOrdersForMonthToExcel
{
    public class GetOrdersForMonthToExcelHandler : IRequestHandler<GetOrdersForMonthToExcelQuery, StringBuilder>
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IExportToExcelServices _exportToExcel;
        private readonly IMapper _automapper;

        public GetOrdersForMonthToExcelHandler(IOrderRepository orderRepository,
                IExportToExcelServices exportToExcel, IMapper automapper)
        {
            _orderRepository = orderRepository;
            _exportToExcel = exportToExcel;
            _automapper = automapper;
        }

        public async Task<StringBuilder> Handle(GetOrdersForMonthToExcelQuery request, CancellationToken cancellationToken)
        {
            var orders = (await _orderRepository.ListAllAsync());

            var orderMapped = _automapper.Map<IReadOnlyList<OrdersForMonthToExcelvm>>(orders);

            var stringBuilder = _exportToExcel.GetOrderToExcel(orderMapped);

            return stringBuilder;
        }
    }
}
