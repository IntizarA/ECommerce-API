using ECommerce.Application.Features.Commands.Order.Create;
using ECommerce.Application.Validators.OrderDetail;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators.Order
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommandRequest>
    {
        public CreateOrderValidator()
        {
            RuleForEach(x => x.OrderDetails).SetValidator(new OrderDetailValidator());
        }

    }
}
