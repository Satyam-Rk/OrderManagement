using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Shared;
using OrderManagement.Domain.Entities;
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

        public async Task<ApiResponse<PagedResponse<Product>>> Handle(GetAllProductsRequest request)
        {
            var products = (await _productRepository.GetAllAsync()).Where(p => !p.IsDeleted).ToList();

            var totalCount = products.Count;

            var pagedItems = products
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize).ToList();

            var pagedResponse = new PagedResponse<Product>
            {
                Items = pagedItems,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            return ApiResponse<PagedResponse<Product>>.SuccessResponse("Products fetched successfully", pagedResponse);
        }
    }
}
