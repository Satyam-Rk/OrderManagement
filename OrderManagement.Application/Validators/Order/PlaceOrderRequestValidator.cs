using FluentValidation;
using OrderManagement.Application.UseCases.Orders.PlaceOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Validators.Order
{
    public class PlaceOrderRequestValidator : AbstractValidator<PlaceOrderRequest>
    {
        public PlaceOrderRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.Items).NotNull().Must(x => x.Count > 0);

            RuleForEach(x => x.Items).SetValidator(new PlaceOrderItemRequestValidator());
        }
    }
}
