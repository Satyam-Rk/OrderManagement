using OrderManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.DeleteProduct
{
    public class DeleteProductHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                return new DeleteProductResponse { Success = false };

            _productRepository.DeleteProduct(product);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteProductResponse { Success = true };
        }
    }
}
