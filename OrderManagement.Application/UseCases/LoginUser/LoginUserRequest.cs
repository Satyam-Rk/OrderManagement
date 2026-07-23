using MediatR;
using OrderManagement.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.LoginUser
{
    public class LoginUserRequest : IRequest<ApiResponse<string>>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
