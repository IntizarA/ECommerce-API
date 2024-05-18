using ECommerce.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public interface ICustomerService
    {
        bool Add(CustomerDTO customer);
        Task<bool> AddAsync(CustomerDTO customer);
        bool AddRange(List<CustomerDTO> range);
        Task<bool> AddRangeAsync(List<CustomerDTO> range);

        bool Remove(CustomerRemoveDTO customer);
        bool RemoveById(string id);
        bool RemoveRange(List<CustomerRemoveDTO> range);

        List<CustomerDTO> GetAll(bool isTracking);
        CustomerDTO? GetById(string id, bool isTracking);
        Task<CustomerDTO?> GetByIdAsync(string id, bool isTracking);
        List<CustomerDTO?> Select(Expression<Func<CustomerDTO, bool>> expression, bool isTracking);

        Task<CustomerDTO?> SingleOrDefaultAsync(string username, bool isTracking);
        Task<bool> IsUserExists(string email);

    }
}
