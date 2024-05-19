
using ECommerce.Application.DTOs.Order;
using ECommerce.Application.DTOs.Product;

namespace ECommerce.Application.Features.Queries.Order.Read
{
    public class GetAllOrderQueryResponse
    {
        public List<string> Errors { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public float TotalPrice { get; set; }
    }
}
