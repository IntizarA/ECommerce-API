using ECommerce.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Abstraction.Services
{
    public interface ICustomerService
    {
        bool Add(CreateCustomerDTO customer);
        Task<bool> AddAsync(CreateCustomerDTO customer);
        bool AddRange(List<CreateCustomerDTO> range);
        Task<bool> AddRangeAsync(List<CreateCustomerDTO> range);

        bool Remove(CustomerRemoveDTO customer);
        bool RemoveById(string id);
        bool RemoveRange(List<CustomerRemoveDTO> range);

        List<CustomerDTO> GetAll(bool isTracking);
        CustomerDTO? GetById(string id, bool isTracking);
        Task<CustomerDTO?> GetByIdAsync(string id, bool isTracking);
        List<CustomerDTO?> Select(Expression<Func<CreateCustomerDTO, bool>> expression, bool isTracking);

        Task<CustomerDTO?> SingleOrDefaultAsync(string username, bool isTracking);
        Task<bool> IsUserExists(string email);

    }
}
