using ECommerce.Application.Features.Commands.Customer.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators.Customer
{
    internal class CreateCustomerValidator : AbstractValidator<CreateCustomerCommandRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("Name is required").Must(IsNotWhiteSpaces).WithMessage("Name must contain non-whitespace characters.");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }

        private bool IsNotWhiteSpaces(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
