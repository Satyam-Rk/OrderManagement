using FluentValidation;
using MediatR;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Shared;
using OrderManagement.Application.Validators;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, ApiResponse<Guid>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateProductRequest> _validator;

        public CreateProductHandler(IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IValidator<CreateProductRequest> validator)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ApiResponse<Guid>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.Errors.First().ErrorMessage);
            }

            var product = new Product(request.Name, request.Category, request.Price, request.StockQuantity);

            await _productRepository.AddProductAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<Guid>.SuccessResponse("Product created successfully", product.Id);
        }
    }
}
