using MediatR;
using OrderManagement.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.RegisterUser
{
    public class RegisterUserRequest : IRequest<ApiResponse<Guid>>
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int RoleId { get; set; }
    }
}
