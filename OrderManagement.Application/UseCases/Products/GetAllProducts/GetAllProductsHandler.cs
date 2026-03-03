using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Shared;
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

        public async Task<PagedResponse<GetAllProductsResponse>> Handle(GetAllProductsRequest request)
        {
            var products = await _productRepository.GetAllAsync();

            var totalCount = products.Count;

            var pagedItems = products
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(product => new GetAllProductsResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    StockQuantity = product.StockQuantity,
                }).ToList();

            return new PagedResponse<GetAllProductsResponse>
            {
                Items = pagedItems,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
