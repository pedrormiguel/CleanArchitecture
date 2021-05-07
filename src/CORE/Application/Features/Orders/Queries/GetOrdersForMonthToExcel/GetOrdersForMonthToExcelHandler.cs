using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Models.Export;
using AutoMapper;
using MediatR;

namespace Application.Features.Orders.Queries.GetOrdersForMonthToExcel
{
    public class GetOrdersForMonthToExcelHandler : IRequestHandler<GetOrdersForMonthToExcelQuery, ExcelFile>
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

        public async Task<ExcelFile> Handle(GetOrdersForMonthToExcelQuery request, CancellationToken cancellationToken)
        {
            var dtos = await _orderRepository.ListAllAsync();

            var orderMapped = _automapper.Map<IReadOnlyCollection<OrdersForMonthToExcelvm>>(dtos);

            return _exportToExcel.GetOrderToExcel(orderMapped);
        }
    }
}
