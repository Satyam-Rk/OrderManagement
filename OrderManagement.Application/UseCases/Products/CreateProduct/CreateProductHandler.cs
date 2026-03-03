using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.CreateProduct
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request)
        {
            var product = new Product(request.Name, request.Category, request.Price, request.StockQuantity);

            await _productRepository.AddProductAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new CreateProductResponse
            {
                Id = product.Id
            };
        }
    }
}
