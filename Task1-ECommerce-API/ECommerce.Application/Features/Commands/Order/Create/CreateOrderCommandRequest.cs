using ECommerce.Application.DTOs.OrderDetail;
using ECommerce.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Commands.Order.Create
{
    public class CreateOrderCommandRequest:IRequest<CreateOrderCommandResponse>
    {
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
