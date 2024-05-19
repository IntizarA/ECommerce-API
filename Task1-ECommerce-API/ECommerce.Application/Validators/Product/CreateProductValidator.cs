using ECommerce.Application.Features.Commands.Customer.Create;
using ECommerce.Application.Features.Commands.Product.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators.Product
{
     class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required").Must(IsNotWhiteSpaces).WithMessage("Name must contain non-whitespace characters.");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description is required").Must(IsNotWhiteSpaces).WithMessage("Description must contain non-whitespace characters.");
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("Stock  must be greater than 0");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }

        private bool IsNotWhiteSpaces(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
