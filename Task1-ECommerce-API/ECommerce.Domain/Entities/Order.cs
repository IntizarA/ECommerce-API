using ECommerce.Domain.Entities.Common;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order:BaseEntity
    {
        public OrderStatus OrderStatus { get;set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer{ get; set; }

        public ICollection<OrderDetail> OrderDetails{ get; set; }
    }
}
