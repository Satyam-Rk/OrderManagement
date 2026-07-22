using MediatR;
using OrderManagement.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.DeleteProduct
{
    public class DeleteProductRequest : IRequest<ApiResponse<string>>
    {
        public Guid Id { get; set; }
    }
}
