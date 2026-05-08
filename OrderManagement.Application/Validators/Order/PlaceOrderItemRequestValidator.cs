using FluentValidation;
using OrderManagement.Application.UseCases.Orders.PlaceOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Validators.Order
{
    public class PlaceOrderItemRequestValidator : AbstractValidator<PlaceOrderItemRequest>
    {
        public PlaceOrderItemRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();

            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
