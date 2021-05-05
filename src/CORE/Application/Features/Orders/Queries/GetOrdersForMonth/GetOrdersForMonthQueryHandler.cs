using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using System.Linq;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class GetOrdersForMonthQueryHandler : IRequestHandler<GetOrderForMonthQuery, GetOrderForMonthResponse>
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _autoMapper;

        public GetOrdersForMonthQueryHandler(IAsyncRepository<Order> orderRepository, IMapper autoMapper)
        {
            _orderRepository = orderRepository;
            _autoMapper = autoMapper;
        }

        public async Task<GetOrderForMonthResponse> Handle(GetOrderForMonthQuery request, CancellationToken cancellationToken)
        {
            var response = new GetOrderForMonthResponse();

            //TODO Review if it is worth it order the list here.
            var orders = (await _orderRepository.ListAllAsync())
                                                .OrderBy(o => o.OrderPlaced);

            if (orders.Any())
            {
                var ordersMapper = _autoMapper.Map<List<OrderForMothVm>>(orders);
                response.OrderForMothVm = ordersMapper;
            }

            return response;
        }
    }
}