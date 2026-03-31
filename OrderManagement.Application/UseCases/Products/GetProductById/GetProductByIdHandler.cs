using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Shared;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.GetProductById
{
    public class GetProductByIdHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<Product>> Handle(GetProductByIdRequest request)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if(product == null || product.IsDeleted)
                return ApiResponse<Product>.FailureResponse("Product not found");

            return ApiResponse<Product>.SucccessResponse("Product fetched successfully", product);
        }
    }
}
