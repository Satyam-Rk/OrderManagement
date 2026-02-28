using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.RegisterUser
{
    public class RegisterUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserHandler(IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request)
        {
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

            return new RegisterUserResponse
            {
                UserId = user.Id,
                Email = user.Email.ToString()
            };
        }
    }
}
