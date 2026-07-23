using FluentValidation;
using MediatR;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Shared;
using OrderManagement.Application.Validators.Order;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.Orders.PlaceOrder
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderRequest, ApiResponse<Guid>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IValidator<PlaceOrderRequest> _validator;

        public PlaceOrderHandler(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IValidator<PlaceOrderRequest> validator)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ApiResponse<Guid>> Handle(PlaceOrderRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ErrorMessage);

            var order = new Order(request.UserId);

            foreach (var item in request.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product == null || product.IsDeleted)
                {
                    return ApiResponse<Guid>.FailureResponse("Product not found");
                }

                if (product.StockQuantity < item.Quantity)
                {
                    return ApiResponse<Guid>.FailureResponse(
                        $"Insufficient stock for product: {product.Name}");
                }

                product.ReduceStock(item.Quantity);

                order.AddItem(
                    product.Id,
                    item.Quantity,
                    product.Price);
            }

            await _orderRepository.AddAsync(order);

            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<Guid>.SuccessResponse(
                "Order placed successfully",
                order.Id);
        }
    }
}
