using MediatR;
using OrderManagement.Application.Shared;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.GetProductById
{
    public class GetProductByIdRequest : IRequest<ApiResponse<Product>>
    {
        public Guid Id { get; set; }
    }
}
