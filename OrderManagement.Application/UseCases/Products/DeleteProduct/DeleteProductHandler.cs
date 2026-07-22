using MediatR;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, ApiResponse<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<string>> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null || product.IsDeleted)
                return ApiResponse<string>.FailureResponse("Product not found");

            _productRepository.DeleteProduct(product);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<string>.SuccessResponse("Product deleted successfully");
        }
    }
}
