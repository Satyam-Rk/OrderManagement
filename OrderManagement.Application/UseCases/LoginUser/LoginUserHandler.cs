using MediatR;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, ApiResponse<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginUserHandler(IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ApiResponse<string>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            //Fetch user
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                throw new Exception("Invalid credentials.");

            //Verify password
            var isValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash);

            if (!isValid)
                throw new Exception("Invalid credentials.");

            //Generate token
            var token = _tokenGenerator.GenerateToken(user.Id, user.Email.ToString(), user.RoleId);

            return ApiResponse<string>.SuccessResponse("Token generated successfully", token);
        }
    }
}
