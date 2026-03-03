using OrderManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.UpdateProduct
{
    public class UpdateProductHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductHandler(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                return new UpdateProductResponse { Success = false };

            product.SetName(request.Name);
            product.SetPrice(request.Price);
            product.SetCategory(request.Category);
            product.SetStock(request.StockQuantity);

            _productRepository.UpdateProduct(product);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateProductResponse { Success = true };
        }
    }
}
