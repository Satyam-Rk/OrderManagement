using FluentValidation;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrderManagement.Application.Shared;
using MediatR;

namespace OrderManagement.Application.UseCases.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, ApiResponse<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidator<RegisterUserRequest> _validator;
        private readonly ILogger<RegisterUserHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IValidator<RegisterUserRequest> validator,
            ILogger<RegisterUserHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<Guid>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ErrorMessage);

            //Check for email uniqueness
            if (await _userRepository.EmailExistsAsync(request.Email))
                throw new Exception("Email already exists.");

            //Hash password
            var hashedPassword =_passwordHasher.HashPassword(request.Password);

            //Validate email
            var email = Email.Create(request.Email);

            //Create domain user
            var user = User.Create(request.Name, email, hashedPassword, request.RoleId);

            await _userRepository.AddUserAsync(user);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("User registered: {Email}", request.Email);

            return ApiResponse<Guid>.SuccessResponse("User registered successfully", user.Id);
        }
    }
}
