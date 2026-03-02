using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.UseCases.LoginUser
{
    public class LoginUserResponse
    {
        public string Token { get; set; } = default!;
    }
}
