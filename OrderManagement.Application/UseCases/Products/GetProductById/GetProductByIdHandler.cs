using OrderManagement.Application.Interfaces;
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

        public async Task<GetProductByIdResponse?> Handle(GetProductByIdRequest request)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if(product == null)
                return null;

            return new GetProductByIdResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                StockQuantity = product.StockQuantity
            };
        }
    }
}
