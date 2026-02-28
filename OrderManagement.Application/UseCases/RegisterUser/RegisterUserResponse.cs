using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.RegisterUser
{
    public class RegisterUserResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = default!;
    }
}
