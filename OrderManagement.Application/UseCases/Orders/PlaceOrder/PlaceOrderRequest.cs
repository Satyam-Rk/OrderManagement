using MediatR;
using OrderManagement.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Orders.PlaceOrder
{
    public class PlaceOrderRequest : IRequest<ApiResponse<Guid>>
    {
        public Guid UserId { get; set; }
        public List<PlaceOrderItemRequest> Items { get; set; } = new();
    }
}
