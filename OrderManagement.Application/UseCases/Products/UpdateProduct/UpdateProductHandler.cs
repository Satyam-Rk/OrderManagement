using FluentValidation;
using MediatR;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ApiResponse<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateProductRequest> _validator;

        public UpdateProductHandler(IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IValidator<UpdateProductRequest> validator)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ApiResponse<string>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.Errors.First().ErrorMessage);
            }

            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                return ApiResponse<string>.FailureResponse("Product not found");

            product.SetName(request.Name);
            product.SetPrice(request.Price);
            product.SetCategory(request.Category);
            product.SetStock(request.StockQuantity);

            _productRepository.UpdateProduct(product);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<string>.SuccessResponse("Product updated successfully");
        }
    }
}
