using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(Guid userId, string email, int roleId);
    }
}
