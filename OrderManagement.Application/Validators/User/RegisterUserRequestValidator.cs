using FluentValidation;
using OrderManagement.Application.UseCases.RegisterUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Validators.User
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Email).NotEmpty().MaximumLength(30);

            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(16);

            RuleFor(x => x.RoleId).GreaterThan(0);
        }
    }
}
