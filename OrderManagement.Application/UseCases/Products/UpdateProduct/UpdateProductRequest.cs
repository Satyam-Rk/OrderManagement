using MediatR;
using OrderManagement.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.UpdateProduct
{
    public class UpdateProductRequest : IRequest<ApiResponse<string>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Category { get; set; } = default!;
        public int StockQuantity { get; set; }
    }
}
