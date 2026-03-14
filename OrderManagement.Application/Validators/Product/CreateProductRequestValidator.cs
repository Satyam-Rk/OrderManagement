using FluentValidation;
using OrderManagement.Application.UseCases.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Validators.Product
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator() 
        {
            RuleFor( x => x.Name).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.Category).NotEmpty().MaximumLength(100);

            RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0);
        }
    }
}
