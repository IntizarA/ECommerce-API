using ECommerce.Application.DTOs.OrderDetail;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators.OrderDetail
{
    public class OrderDetailValidator:AbstractValidator<OrderDetailDTO>
    {
        public OrderDetailValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("UnitPrice must be greater than 0");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId cannot be empty");
        }
    }
}
