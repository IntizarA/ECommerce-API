using ECommerce.Application.DTOs.Order;
using ECommerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Abstraction.Services
{
    public interface IOrderService
    {
        bool Add(OrderDTO order);
        Task<bool> AddAsync(OrderDTO order);
        bool AddRange(List<OrderDTO> range);
        Task<bool> AddRangeAsync(List<OrderDTO> range);
        bool Update(UpdateOrderDTO order);
        bool Remove(OrderDTO order);
        bool RemoveById(string id);
        bool RemoveRange(List<OrderDTO> range);

        List<OrderDTO> GetAll(bool isTracking);
        OrderDTO? GetById(string id, bool isTracking);
        Task<OrderDTO?> GetByIdAsync(string id, bool isTracking);
        List<OrderDTO?> Select(Expression<Func<OrderDTO, bool>> expression, bool isTracking);
    }
}
