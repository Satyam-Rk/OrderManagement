using OrderManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.GetAllProducts
{
    public class GetAllProductsHandler
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsRequest request)
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(product => new GetAllProductsResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                StockQuantity = product.StockQuantity,
            }).ToList();
        }
    }
}
