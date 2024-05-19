using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.OrderDetail
{
    public class OrderDetailDTO
    {
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public string ProductId { get; set; }
    }
}
