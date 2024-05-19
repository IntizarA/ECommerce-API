using ECommerce.Application.DTOs.OrderDetail;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Order
{
    public class OrderDTO
    {
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
